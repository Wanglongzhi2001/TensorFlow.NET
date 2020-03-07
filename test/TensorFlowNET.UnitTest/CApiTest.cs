﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tensorflow;

namespace TensorFlowNET.UnitTest
{
    public class CApiTest
    {
        protected TF_Code TF_OK = TF_Code.TF_OK;
        protected TF_DataType TF_FLOAT = TF_DataType.TF_FLOAT;

        protected void EXPECT_TRUE(bool expected, string msg = "")
            => Assert.IsTrue(expected, msg);

        protected void EXPECT_EQ(object expected, object actual, string msg = "")
            => Assert.AreEqual(expected, actual, msg);

        protected void CHECK_EQ(object expected, object actual, string msg = "")
            => Assert.AreEqual(expected, actual, msg);

        protected void EXPECT_NE(object expected, object actual, string msg = "")
            => Assert.AreNotEqual(expected, actual, msg);

        protected void EXPECT_GE(int expected, int actual, string msg = "")
            => Assert.IsTrue(expected >= actual, msg);

        protected void ASSERT_EQ(object expected, object actual, string msg = "")
            => Assert.AreEqual(expected, actual, msg);

        protected void ASSERT_TRUE(bool condition, string msg = "")
            => Assert.IsTrue(condition, msg);

        protected OperationDescription TF_NewOperation(Graph graph, string opType, string opName)
            => c_api.TF_NewOperation(graph, opType, opName);

        protected void TF_AddInput(OperationDescription desc, TF_Output input)
            => c_api.TF_AddInput(desc, input);

        protected Operation TF_FinishOperation(OperationDescription desc, Status s)
            => c_api.TF_FinishOperation(desc, s);

        protected void TF_SetAttrTensor(OperationDescription desc, string attrName, Tensor value, Status s)
            => c_api.TF_SetAttrTensor(desc, attrName, value, s);

        protected void TF_SetAttrType(OperationDescription desc, string attrName, TF_DataType dtype)
            => c_api.TF_SetAttrType(desc, attrName, dtype);

        protected void TF_SetAttrBool(OperationDescription desc, string attrName, bool value)
            => c_api.TF_SetAttrBool(desc, attrName, value);

        protected TF_Code TF_GetCode(Status s)
            => s.Code;

        protected TF_Code TF_GetCode(IntPtr s)
            => c_api.TF_GetCode(s);

        protected string TF_Message(IntPtr s)
            => c_api.StringPiece(c_api.TF_Message(s));
    }
}
