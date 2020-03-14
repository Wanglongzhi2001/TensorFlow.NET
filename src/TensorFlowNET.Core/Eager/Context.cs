﻿using System;

namespace Tensorflow.Eager
{
    public class Context : DisposableObject
    {
        public const int GRAPH_MODE = 0;
        public const int EAGER_MODE = 1;

        public int default_execution_mode;
        public string device_name = "";
        bool _initialized = false;

        public Context(ContextOptions opts, Status status)
        {
            _handle = c_api.TFE_NewContext(opts, status);
            status.Check(true);
        }

        public void ensure_initialized()
        {
            if (_initialized)
                return;
            _initialized = true;
        }

        /// <summary>
        ///     Dispose any unmanaged resources related to given <paramref name="handle"/>.
        /// </summary>
        protected sealed override void DisposeUnmanagedResources(IntPtr handle) 
            => c_api.TFE_DeleteContext(_handle);


        public bool executing_eagerly() => true;

        public static implicit operator IntPtr(Context ctx) 
            => ctx._handle;

        public static implicit operator TFE_Context(Context ctx)
            => new TFE_Context(ctx._handle);
    }
}
