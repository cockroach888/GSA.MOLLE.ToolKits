//==================================================================== 
//*****                     晨曦小竹常用工具集                   *****
//====================================================================
//**   Copyright © DawnXZ.com 2014 -- QQ：6808240 -- 请保留此注释   **
//====================================================================
// 文件名称：ConvertorHelper.cs
// 项目名称：常用方法实用工具集
// 创建时间：2016-07-29 14:15:57
// 创建人员：宋杰军
// 负 责 人：宋杰军
// 参与人员：宋杰军
// ===================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ===================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.ComponentModel;

namespace DawnXZ.DawnUtility {
	/// <summary>
	/// 实体和泛型集合与DataTable数据相互转换帮助类
	/// <remarks>
	///	<para>default关键字释义：</para>
	///	<para>1、此关键字对于引用类型会返回空，对于数值类型会返回零；</para>
	///	<para>2、对于结构，此关键字将返回初始化为零或空的每个结构成员，具体取决于这些结构是值类型还是引用类型</para>
	/// </remarks>
	/// </summary>
	public static class ConvertorHelper {

		#region 赋予实体对象属性值

		/// <summary>
		/// 赋予实体对象属性值
		/// </summary>
		/// <typeparam name="T">实体对象</typeparam>
		/// <param name="t">实体对象</param>
		/// <param name="pi">实体对象属性</param>
		/// <param name="value">值</param>
		private static void SetValue<T>(T t, PropertyInfo pi, object value) {
			switch (pi.PropertyType.ToString()) {
				case "System.Nullable`1[System.String]":
				case "System.String":
					pi.SetValue(t, Convert.ToString(value), null);
					break;
				case "System.Nullable`1[System.Int16]":
				case "System.Int16":
					pi.SetValue(t, Convert.ToInt16(value), null);
					break;
				case "System.Nullable`1[System.Int32]":
				case "System.Int32":
					pi.SetValue(t, Convert.ToInt32(value), null);
					break;
				case "System.Nullable`1[System.Int64]":
				case "System.Int64":
					pi.SetValue(t, Convert.ToInt64(value), null);
					break;
				case "System.Nullable`1[System.UInt16]":
				case "System.UInt16":
					pi.SetValue(t, Convert.ToUInt16(value), null);
					break;
				case "System.Nullable`1[System.UInt32]":
				case "System.UInt32":
					pi.SetValue(t, Convert.ToUInt32(value), null);
					break;
				case "System.Nullable`1[System.UInt64]":
				case "System.UInt64":
					pi.SetValue(t, Convert.ToUInt64(value), null);
					break;
				case "System.Nullable`1[System.DateTime]":
				case "System.DateTime":
					pi.SetValue(t, Convert.ToDateTime(value), null);
					break;
				case "System.Nullable`1[System.Boolean]":
				case "System.Boolean":
					pi.SetValue(t, Convert.ToBoolean(value), null);
					break;
				case "System.Nullable`1[System.Double]":
				case "System.Double":
					pi.SetValue(t, Convert.ToDouble(value), null);
					break;
				case "System.Nullable`1[System.Decimal]":
				case "System.Decimal":
					pi.SetValue(t, Convert.ToDecimal(value), null);
					break;
				case "System.Nullable`1[System.Single]":
				case "System.Single":
					pi.SetValue(t, Convert.ToSingle(value), null);
					break;
				case "System.Nullable`1[System.Byte]":
				case "System.Byte":
					pi.SetValue(t, Convert.ToByte(value), null);
					break;
				case "System.Byte[]":
					pi.SetValue(t, value as byte[], null);
					break;
				case "System.Nullable`1[System.Guid]":
				case "System.Guid":
					pi.SetValue(t, new Guid(value.ToString()), null);
					break;
				case "System.Nullable`1[System.SByte]":
				case "System.SByte":
					pi.SetValue(t, Convert.ToSByte(value), null);
					break;
				case "System.Nullable`1[System.Char]":
				case "System.Char":
					pi.SetValue(t, Convert.ToChar(value), null);
					break;
				default:
					pi.SetValue(t, value, null);
					break;
			}
		}

		#endregion

		#region 将DataRow数据对象转换为实体对象

		/// <summary>
		/// 将DataTable的第一个DataRow数据对象转换为实体对象
		/// </summary>
		/// <typeparam name="T">实体对象</typeparam>
		/// <param name="dt">DataTable数据表对象</param>
		/// <returns>转换结果</returns>
		public static T DataRowFirstToEntity<T>(DataTable dt) where T : new() {
			if (null == dt || dt.Rows.Count < 1) return default(T);
			return DataRowToEntity<T>(dt.Rows[0]);
		}
		/// <summary>
		/// 将DataRow数据对象转换为实体对象
		/// </summary>
		/// <typeparam name="T">实体对象</typeparam>
		/// <param name="dr">DataRow数据行对象</param>
		/// <returns>转换结果</returns>
		public static T DataRowToEntity<T>(DataRow dr) where T : new() {
			//T t = (T)Activator.CreateInstance(typeof(T));
			T t = new T();
			if (null == dr) return default(T);
			//获得此模型的公共属性
			PropertyInfo[] _propertys = t.GetType().GetProperties();
			DataColumnCollection _columns = dr.Table.Columns;
			//DBColumn _dbColumn;
			object _value;
			foreach (PropertyInfo p in _propertys) {
				//_dbColumn = p.GetCustomAttributes(typeof(DBColumn), false)[0] as DBColumn;
				//if (null == _dbColumn) continue;
				if (_columns.Contains(p.Name)) {
					_value = dr[p.Name];
					if (!p.CanWrite || _value is DBNull || _value == DBNull.Value) continue; //只读属性
					try {
						SetValue<T>(t, p, _value);
					}
					catch {
						continue;
					}
				}
			}
			return t;
		}

		#endregion

		#region 将DataTable数据对象转换为泛型集合对象

		/// <summary>
		/// 将DataTable数据对象转换为泛型集合对象
		/// </summary>
		/// <typeparam name="T">实体对象</typeparam>
		/// <param name="dt">DataTable数据表对象</param>
		/// <returns>转换结果</returns>
		public static IList<T> DataTableToList<T>(DataTable dt) where T : new() {
			IList<T> list = new List<T>();
			if (null == dt || dt.Rows.Count < 1) return list;
			T t;
			foreach (DataRow dr in dt.Rows) {
				t = DataRowToEntity<T>(dr);
				if (null != t) list.Add(t);
			}
			return list;
		}

		#endregion

		#region 将DataReader数据对象转换为实体对象

		/// <summary>
		/// 将DataReader数据对象转换为实体对象
		/// </summary>
		/// <typeparam name="T">实体对象</typeparam>
		/// <param name="dr">IDataReader数据对象</param>
		/// <returns>转换结果</returns>
		public static T DataReaderToEntity<T>(IDataReader dr) where T : new() {
			T t = new T();
			if (dr == null) return default(T);
			using (dr) {
				if (dr.Read()) {
					//获得此模型的公共属性
					PropertyInfo[] propertys = t.GetType().GetProperties();
					List<string> listFieldName = new List<string>(dr.FieldCount);
					for (int i = 0; i < dr.FieldCount; i++) {
						listFieldName.Add(dr.GetName(i).ToLower());
					}
					object _value;
					foreach (PropertyInfo p in propertys) {
						if (!listFieldName.Contains(p.Name.ToLower())) continue;
						_value = dr[p.Name];
						if (!p.CanWrite || _value is DBNull || _value == DBNull.Value) continue; //只读属性
						try {
							SetValue<T>(t, p, _value);
						}
						catch { ;}
					}
				}
			}
			return t;
		}

		#endregion

		#region 将DataReader数据对象转换为泛型集合对象

		/// <summary>
		/// 将DataReader数据对象转换为泛型集合对象
		/// </summary>
		/// <typeparam name="T">实体对象</typeparam>
		/// <param name="dr">IDataReader数据对象</param>
		/// <returns>转换结果</returns>
		public static List<T> DataReaderToList<T>(IDataReader dr) where T : new() {
			List<T> list = new List<T>();
			if (null == dr) return list;
			T t1 = new T();
			PropertyInfo[] propertys = t1.GetType().GetProperties();
			using (dr) {
				List<string> listFieldName = new List<string>(dr.FieldCount);
				for (int i = 0; i < dr.FieldCount; i++) {
					listFieldName.Add(dr.GetName(i).ToLower());
				}
				while (dr.Read()) {
					T t = new T();
					object _value;
					foreach (PropertyInfo p in propertys) {
						if (!listFieldName.Contains(p.Name.ToLower())) continue;
						_value = dr[p.Name];
						if (!p.CanWrite || _value is DBNull || _value == DBNull.Value) continue; //只读属性
						try {
							SetValue<T>(t, p, _value);
						}
						catch { ;}
					}
					list.Add(t);
				}
			}
			return list;
		}

		#endregion

		#region 将泛型集合对象转换为DataTable数据对象

		/// <summary>
		/// 将泛型集合对象转换为DataTable数据对象
		/// </summary>
		/// <typeparam name="T">实体对象</typeparam>
		/// <param name="entityList">泛型集合对象</param>
		/// <returns>转换结果</returns>
		public static DataTable ListToDataTable<T>(IList<T> entityList) {
			if (null == entityList) return null;
			DataTable dt = CreateTable<T>();
			Type entityType = typeof(T);
			//PropertyInfo[] properties = entityType.GetProperties();
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
			foreach (T item in entityList) {
				DataRow row = dt.NewRow();
				foreach (PropertyDescriptor property in properties) {
					row[property.Name] = property.GetValue(item);
				}
				dt.Rows.Add(row);
			}
			return dt;
		}

		#endregion

		#region 根据实体对象创建相应的DataTable数据对象

		/// <summary>
		/// 根据实体对象创建相应的DataTable数据对象
		/// </summary>
		/// <typeparam name="T">实体对象</typeparam>
		/// <returns>DataTable数据对象</returns>
		private static DataTable CreateTable<T>() {
			Type entityType = typeof(T);
			//PropertyInfo[] properties = entityType.GetProperties();
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
			//生成DataTable的结构
			DataTable dt = new DataTable();
			foreach (PropertyDescriptor prop in properties) {
				dt.Columns.Add(prop.Name);
			}
			return dt;
		}

		#endregion

	}

	#region 数据库字段对应属性类

	/// <summary>
	/// 数据库字段对应属性类
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	public class DBColumn : Attribute {
		/// <summary>
		/// 数据库字段
		/// </summary>
		public string ColName { get; set; }
		/*
		AttributeTargets 枚举 
		成员名称 说明 
		All 可以对任何应用程序元素应用属性。  
		Assembly 可以对程序集应用属性。  
		Class 可以对类应用属性。  
		Constructor 可以对构造函数应用属性。  
		Delegate 可以对委托应用属性。  
		Enum 可以对枚举应用属性。  
		Event 可以对事件应用属性。  
		Field 可以对字段应用属性。  
		GenericParameter 可以对泛型参数应用属性。  
		Interface 可以对接口应用属性。  
		Method 可以对方法应用属性。  
		Module 可以对模块应用属性。 注意 
		Module 指的是可移植的可执行文件（.dll 或 .exe），而非 Visual Basic 标准模块。
		Parameter 可以对参数应用属性。  
		Property 可以对属性 (Property) 应用属性 (Attribute)。  
		ReturnValue 可以对返回值应用属性。  
		Struct 可以对结构应用属性，即值类型 
		*/

		/*
		这里会有四种可能的组合： 
		[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false ] 
		[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false ] 
		[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true ] 
		[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true ]

		第一种情况：
			如果我们查询Derive类，我们将会发现Help特性并不存在，因为inherited属性被设置为false。
		
		第二种情况：
			和第一种情况相同，因为inherited也被设置为false。
		
		第三种情况：
			为了解释第三种和第四种情况，我们先来给派生类添加点代码： 
   
		[Help("BaseClass")] 
		public class Base { }
		
		[Help("DeriveClass")] 
		public class Derive : Base { }

		现在我们来查询一下Help特性，我们只能得到派生类的属性，因为inherited被设置为true，但是AllowMultiple却被设置为false。
		因此基类的Help特性被派生类Help特性覆盖了。

		第四种情况：
			在这里，我们将会发现派生类既有基类的Help特性，也有自己的Help特性，因为AllowMultiple被设置为true。
		*/
	}

	#endregion

}
