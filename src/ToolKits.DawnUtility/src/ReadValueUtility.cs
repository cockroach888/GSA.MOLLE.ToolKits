//=========================================================================
//**   魂哥常用工具集（CRS.CommonUtility）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2021 -- Support 文雀
//=========================================================================
// 文件名称：ReadValueUtility.cs
// 项目名称：常用方法实用工具集
// 创建时间：2019-11-07 10:29:31
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.IO;
using System.Text;

namespace GSA.ToolKits.DawnUtility
{
    /// <summary>
    /// 数据读取与解析BIUBIU工具集
    /// </summary>
    public static class ReadValueUtility
    {
        /// <summary>
        /// 数据类型字节占用长度 - byte
        /// </summary>
        public const int ByteLength = 1;
        /// <summary>
        /// 数据类型字节占用长度 - short
        /// </summary>
        public const int ShortLength = 2;
        /// <summary>
        /// 数据类型字节占用长度 - int
        /// </summary>
        public const int IntLength = 4;
        /// <summary>
        /// 数据类型字节占用长度 - single
        /// </summary>
        public const int SingleLength = 4;
        /// <summary>
        /// 数据类型字节占用长度 - double
        /// </summary>
        public const int DoubleLength = 8;


        /// <summary>
        /// 查找指定字节数组的位置
        /// </summary>
        /// <param name="srcBufs">数据缓冲区对象</param>
        /// <param name="startIndex">开始索引位</param>
        /// <param name="objBuf">结束符</param>
        /// <returns>结束索引位</returns>
        public static int FindBytesIndex(byte[] srcBufs, int startIndex, byte objBuf)
        {
            int index = -1;
            int i = startIndex;
            for (; i < srcBufs.Length; i++) if (srcBufs[i] == objBuf) return i;
            return index <= 0 ? srcBufs.Length : index;
        }

        #region Read String Value

        /// <summary>
        /// 从数据缓冲区读取字符串值
        /// </summary>
        /// <param name="bs">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <param name="defValue">默认缺省值</param>
        /// <param name="objBuf">结束符</param>
        /// <returns>字符串值</returns>
        public static string ReadString(BufferedStream bs, int dataLength, string defValue, byte objBuf)
        {
            byte[] buffer = new byte[dataLength];
            bs.Read(buffer, 0, dataLength);
            var endIndex = FindBytesIndex(buffer, 0, objBuf);
            var result = Encoding.Default.GetString(buffer, 0, endIndex);
            Array.Clear(buffer, 0, dataLength);
            return string.IsNullOrEmpty(result) ? defValue : result;
        }
        /// <summary>
        /// 从数据缓冲区读取字符串值
        /// </summary>
        /// <param name="br">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <param name="defValue">默认缺省值</param>
        /// <param name="objBuf">结束符</param>
        /// <returns>字符串值</returns>
        public static string ReadString(BinaryReader br, int dataLength, string defValue, byte objBuf)
        {
            byte[] buffer = new byte[dataLength];
            br.Read(buffer, 0, dataLength);
            var endIndex = FindBytesIndex(buffer, 0, objBuf);
            var result = Encoding.Default.GetString(buffer, 0, endIndex);
            Array.Clear(buffer, 0, dataLength);
            return string.IsNullOrEmpty(result) ? defValue : result;
        }
        /// <summary>
        /// 从数据缓冲区读取字符串值
        /// </summary>
        /// <param name="srcBuffer">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="defValue">默认缺省值</param>
        /// <param name="objBuf">结束符</param>
        /// <returns>字符串值</returns>
        public static string ReadString(byte[] srcBuffer, int dataLength, ref int startIndex, string defValue, byte objBuf)
        {
            byte[] buffer = new byte[dataLength];
            Buffer.BlockCopy(srcBuffer, startIndex, buffer, 0, dataLength);
            var endIndex = FindBytesIndex(buffer, 0, objBuf);
            var result = Encoding.Default.GetString(buffer, 0, endIndex);
            Array.Clear(buffer, 0, dataLength);
            startIndex += dataLength;
            return string.IsNullOrEmpty(result) ? defValue : result;
        }
        /// <summary>
        /// 从数据缓冲区读取字符串值
        /// </summary>
        /// <param name="srcBuffer">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="defValue">默认缺省值</param>
        /// <param name="objBuf">结束符</param>
        /// <returns>字符串值</returns>
        public static string ReadStringAt(byte[] srcBuffer, int dataLength, int startIndex, string defValue, byte objBuf)
        {
            byte[] buffer = new byte[dataLength];
            Buffer.BlockCopy(srcBuffer, startIndex, buffer, 0, dataLength);
            var endIndex = FindBytesIndex(buffer, 0, objBuf);
            var result = Encoding.Default.GetString(buffer, 0, endIndex);
            Array.Clear(buffer, 0, dataLength);
            return string.IsNullOrEmpty(result) ? defValue : result;
        }

        #endregion

        #region Read String Array Value

        /// <summary>
        /// 从数据缓冲区读取字符串值
        /// </summary>
        /// <param name="bs">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <param name="dataSize">数据大小</param>
        /// <param name="objBuf">结束符</param>
        /// <returns>字符串值</returns>
        public static string[] ReadStringArray(BufferedStream bs, int dataLength, int dataSize, byte objBuf)
        {
            var result = new string[dataSize];
            byte[] buffer;
            for (int i = 0; i < dataSize; i++)
            {
                buffer = new byte[dataLength];
                bs.Read(buffer, 0, dataLength);
                var endIndex = FindBytesIndex(buffer, 0, objBuf);
                result[i] = Encoding.Default.GetString(buffer, 0, endIndex);
                Array.Clear(buffer, 0, dataLength);
            }
            return result;
        }
        /// <summary>
        /// 从数据缓冲区读取字符串值
        /// </summary>
        /// <param name="br">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <param name="dataSize">数据大小</param>
        /// <param name="objBuf">结束符</param>
        /// <returns>字符串值</returns>
        public static string[] ReadStringArray(BinaryReader br, int dataLength, int dataSize, byte objBuf)
        {
            var result = new string[dataSize];
            byte[] buffer;
            for (int i = 0; i < dataSize; i++)
            {
                buffer = new byte[dataLength];
                br.Read(buffer, 0, dataLength);
                var endIndex = FindBytesIndex(buffer, 0, objBuf);
                result[i] = Encoding.Default.GetString(buffer, 0, endIndex);
                Array.Clear(buffer, 0, dataLength);
            }
            return result;
        }
        /// <summary>
        /// 从数据缓冲区读取字符串值
        /// </summary>
        /// <param name="srcBuffer">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <param name="dataSize">数据大小</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="objBuf">结束符</param>
        /// <returns>字符串值</returns>
        public static string[] ReadStringArray(byte[] srcBuffer, int dataLength, int dataSize, ref int startIndex, byte objBuf)
        {
            var result = new string[dataSize];
            byte[] buffer;
            for (int i = 0; i < dataSize; i++)
            {
                buffer = new byte[dataLength];
                Buffer.BlockCopy(srcBuffer, startIndex, buffer, 0, dataLength);
                var endIndex = FindBytesIndex(buffer, 0, objBuf);
                result[i] = Encoding.Default.GetString(buffer, 0, endIndex);
                Array.Clear(buffer, 0, dataLength);
                startIndex += dataLength;
            }
            return result;
        }

        #endregion

        #region Read Short & Int16 Value

        /// <summary>
        /// 从数据缓冲区读取Short - Int16值
        /// </summary>
        /// <param name="bs">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Short值</returns>
        public static short ReadShort(BufferedStream bs, int dataLength = ShortLength)
        {
            byte[] buffer = new byte[dataLength];
            bs.Read(buffer, 0, dataLength);
            var result = BitConverter.ToInt16(buffer, 0);
            Array.Clear(buffer, 0, dataLength);
            return result;
        }
        /// <summary>
        /// 从数据缓冲区读取Short - Int16值
        /// </summary>
        /// <param name="srcBuffer">数据缓冲区</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Short值</returns>
        public static short ReadShort(byte[] srcBuffer, ref int startIndex, int dataLength = ShortLength)
        {
            byte[] buffer = new byte[dataLength];
            Buffer.BlockCopy(srcBuffer, startIndex, buffer, 0, dataLength);
            var result = BitConverter.ToInt16(buffer, 0);
            Array.Clear(buffer, 0, dataLength);
            startIndex += dataLength;
            return result;
        }

        #endregion

        #region Read Int Value

        /// <summary>
        /// 从数据缓冲区读取Int值
        /// </summary>
        /// <param name="bs">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Int值</returns>
        public static int ReadInt(BufferedStream bs, int dataLength = IntLength)
        {
            byte[] buffer = new byte[dataLength];
            bs.Read(buffer, 0, dataLength);
            var result = BitConverter.ToInt32(buffer, 0);
            Array.Clear(buffer, 0, dataLength);
            return result;
        }
        /// <summary>
        /// 从数据缓冲区读取Int值
        /// </summary>
        /// <param name="srcBuffer">数据缓冲区</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Int值</returns>
        public static int ReadInt(byte[] srcBuffer, ref int startIndex, int dataLength = IntLength)
        {
            byte[] buffer = new byte[dataLength];
            Buffer.BlockCopy(srcBuffer, startIndex, buffer, 0, dataLength);
            var result = BitConverter.ToInt32(buffer, 0);
            Array.Clear(buffer, 0, dataLength);
            startIndex += dataLength;
            return result;
        }

        #endregion

        #region Read Single Value

        /// <summary>
        /// 从数据缓冲区读取Single值
        /// <para>float</para>
        /// </summary>
        /// <param name="bs">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Single值</returns>
        public static float ReadSingle(BufferedStream bs, int dataLength = SingleLength)
        {
            byte[] buffer = new byte[dataLength];
            bs.Read(buffer, 0, dataLength);
            var result = BitConverter.ToSingle(buffer, 0);
            Array.Clear(buffer, 0, dataLength);
            return result;
        }
        /// <summary>
        /// 从数据缓冲区读取Single值
        /// <para>float</para>
        /// </summary>
        /// <param name="srcBuffer">数据缓冲区</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Single值</returns>
        public static float ReadSingle(byte[] srcBuffer, ref int startIndex, int dataLength = SingleLength)
        {
            byte[] buffer = new byte[dataLength];
            Buffer.BlockCopy(srcBuffer, startIndex, buffer, 0, dataLength);
            var result = BitConverter.ToSingle(buffer, 0);
            Array.Clear(buffer, 0, dataLength);
            startIndex += dataLength;
            return result;
        }
        /// <summary>
        /// 从数据缓冲区读取Single值
        /// <para>float</para>
        /// </summary>
        /// <param name="srcBuffer">数据缓冲区</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Single值</returns>
        public static float ReadSingleAt(byte[] srcBuffer, int startIndex, int dataLength = SingleLength)
        {
            byte[] buffer = new byte[dataLength];
            Buffer.BlockCopy(srcBuffer, startIndex, buffer, 0, dataLength);
            var result = BitConverter.ToSingle(buffer, 0);
            Array.Clear(buffer, 0, dataLength);
            return result;
        }

        #endregion

        #region Read Double Value

        /// <summary>
        /// 从数据缓冲区读取Double值
        /// <para>float</para>
        /// </summary>
        /// <param name="bs">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Double值</returns>
        public static double ReadDouble(BufferedStream bs, int dataLength = DoubleLength)
        {
            byte[] buffer = new byte[dataLength];
            bs.Read(buffer, 0, dataLength);
            var result = BitConverter.ToDouble(buffer, 0);
            Array.Clear(buffer, 0, dataLength);
            return result;
        }
        /// <summary>
        /// 从数据缓冲区读取Double值
        /// <para>float</para>
        /// </summary>
        /// <param name="srcBuffer">数据缓冲区</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Double值</returns>
        public static double ReadDouble(byte[] srcBuffer, ref int startIndex, int dataLength = DoubleLength)
        {
            byte[] buffer = new byte[dataLength];
            Buffer.BlockCopy(srcBuffer, startIndex, buffer, 0, dataLength);
            var result = BitConverter.ToDouble(buffer, 0);
            Array.Clear(buffer, 0, dataLength);
            startIndex += dataLength;
            return result;
        }
        /// <summary>
        /// 从数据缓冲区读取Double值
        /// <para>float</para>
        /// </summary>
        /// <param name="srcBuffer">数据缓冲区</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Double值</returns>
        public static double ReadDoubleAt(byte[] srcBuffer, int startIndex, int dataLength = DoubleLength)
        {
            byte[] buffer = new byte[dataLength];
            Buffer.BlockCopy(srcBuffer, startIndex, buffer, 0, dataLength);
            var result = BitConverter.ToDouble(buffer, 0);
            Array.Clear(buffer, 0, dataLength);
            return result;
        }

        #endregion

        #region Read Byte Value

        /// <summary>
        /// 从数据缓冲区读取Byte值
        /// <para>float</para>
        /// </summary>
        /// <param name="bs">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Byte值</returns>
        public static byte ReadByte(BufferedStream bs, int dataLength = ByteLength)
        {
            byte[] buffer = new byte[dataLength];
            bs.Read(buffer, 0, dataLength);
            var result = buffer[0];
            Array.Clear(buffer, 0, dataLength);
            return result;
        }
        /// <summary>
        /// 从数据缓冲区读取Byte值
        /// <para>float</para>
        /// </summary>
        /// <param name="srcBuffer">数据缓冲区</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Byte值</returns>
        public static byte ReadByte(byte[] srcBuffer, ref int startIndex, int dataLength = ByteLength)
        {
            byte[] buffer = new byte[dataLength];
            Buffer.BlockCopy(srcBuffer, startIndex, buffer, 0, dataLength);
            var result = buffer[0];
            Array.Clear(buffer, 0, dataLength);
            startIndex += dataLength;
            return result;
        }
        /// <summary>
        /// 从数据缓冲区读取Byte值
        /// <para>float</para>
        /// </summary>
        /// <param name="srcBuffer">数据缓冲区</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Byte值</returns>
        public static byte ReadByteAt(byte[] srcBuffer, int startIndex, int dataLength = ByteLength)
        {
            byte[] buffer = new byte[dataLength];
            Buffer.BlockCopy(srcBuffer, startIndex, buffer, 0, dataLength);
            var result = buffer[0];
            Array.Clear(buffer, 0, dataLength);
            return result;
        }

        #endregion

        #region Read Single Array Value

        /// <summary>
        /// 从数据缓冲区读取Single Array值
        /// <para>float[]</para>
        /// </summary>
        /// <param name="bs">数据缓冲区</param>
        /// <param name="dataSize">数据大小</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Single Array值</returns>
        public static float[] ReadSingleArray(BufferedStream bs, int dataSize, int dataLength = SingleLength)
        {
            var result = new float[dataSize];
            byte[] buffer;
            for (int i = 0; i < dataSize; i++)
            {
                buffer = new byte[dataLength];
                bs.Read(buffer, 0, dataLength);
                result[i] = BitConverter.ToSingle(buffer, 0);
                Array.Clear(buffer, 0, dataLength);
            }
            return result;
        }
        /// <summary>
        /// 从数据缓冲区读取Single Array值
        /// <para>float[]</para>
        /// </summary>
        /// <param name="br">数据缓冲区</param>
        /// <param name="dataSize">数据大小</param>
        /// <returns>Single Array值</returns>
        public static float[] ReadSingleArray(BinaryReader br, int dataSize)
        {
            var result = new float[dataSize];
            for (int i = 0; i < dataSize; i++) result[i] = br.ReadSingle();
            return result;
        }
        /// <summary>
        /// 从数据缓冲区读取Single Array值
        /// <para>float[]</para>
        /// </summary>
        /// <param name="srcBuffer">数据缓冲区</param>
        /// <param name="dataSize">数据大小</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>Single Array值</returns>
        public static float[] ReadSingleArray(byte[] srcBuffer, int dataSize, ref int startIndex, int dataLength = SingleLength)
        {
            var result = new float[dataSize];
            byte[] buffer;
            for (int i = 0; i < dataSize; i++)
            {
                buffer = new byte[dataLength];
                Buffer.BlockCopy(srcBuffer, startIndex, buffer, 0, dataLength);
                result[i] = BitConverter.ToSingle(buffer, 0);
                Array.Clear(buffer, 0, dataLength);
                startIndex += dataLength;
            }
            return result;
        }

        #endregion

        #region Read Byte Array Value

        /// <summary>
        /// 从数据缓冲区读取字节数组
        /// </summary>
        /// <param name="bs">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>字节数组</returns>
        public static byte[] ReadByteArray(BufferedStream bs, int dataLength)
        {
            byte[] buffer = new byte[dataLength];
            bs.Read(buffer, 0, dataLength);
            return buffer;
        }
        /// <summary>
        /// 从数据缓冲区读取字节数组
        /// </summary>
        /// <param name="br">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns>字节数组</returns>
        public static byte[] ReadByteArray(BinaryReader br, int dataLength)
        {
            byte[] buffer = new byte[dataLength];
            br.Read(buffer, 0, dataLength);
            return buffer;
        }
        /// <summary>
        /// 从数据缓冲区读取字节数组
        /// </summary>
        /// <param name="srcBuffer">数据缓冲区</param>
        /// <param name="dataLength">数据长度</param>
        /// <param name="startIndex">开始位置</param>
        /// <returns>字节数组</returns>
        public static byte[] ReadByteArray(byte[] srcBuffer, int dataLength, ref int startIndex)
        {
            byte[] buffer = new byte[dataLength];
            Buffer.BlockCopy(srcBuffer, startIndex, buffer, 0, dataLength);
            startIndex += dataLength;
            return buffer;
        }

        #endregion

        #region 读取浮点值并进行无效值转换处理

        /// <summary>
        /// 读取浮点值并进行无效值转换处理
        /// </summary>
        /// <param name="br">当前的数据流对象</param>
        /// <param name="invalidValue">无效值</param>
        /// <returns>转换值</returns>
        public static float InvalidConvert(BinaryReader br, float invalidValue = 9999f)
        {
            var tmpValue = br.ReadSingle();
            return tmpValue >= invalidValue ? invalidValue : tmpValue;
        }
        /// <summary>
        /// 读取浮点值并进行无效值转换处理
        /// <para>float</para>
        /// </summary>
        /// <param name="srcBuffer">数据缓冲区</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="dataLength">数据长度</param>
        /// <param name="invalidValue">无效值</param>
        /// <returns>Single值</returns>
        public static float InvalidConvert(byte[] srcBuffer, ref int startIndex, int dataLength = SingleLength, float invalidValue = 9999f)
        {
            byte[] buffer = new byte[dataLength];
            Buffer.BlockCopy(srcBuffer, startIndex, buffer, 0, dataLength);
            var tmpValue = BitConverter.ToSingle(buffer, 0);
            Array.Clear(buffer, 0, dataLength);
            startIndex += dataLength;
            return tmpValue >= invalidValue ? invalidValue : tmpValue;
        }

        #endregion

    }
}
