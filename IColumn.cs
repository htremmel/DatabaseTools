/*
 * Created by SharpDevelop.
 * User: HTREMMEL
 * Date: 3/1/2016
 * Time: 5:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;

namespace DatabaseTools
{
	/// <summary>
	/// Description of Interface1.
	/// </summary>
	public interface IColumn
	{
		string Name { get; set; }
		DbType DbType { get; }
        Type Type { get; }  
        string TypeName { get; }
		int Order { get; }
		ITable<T> Parent { get; } 
        ITable<T> RelatedTabe { get; }
        bool IsKey { get; }
        bool IsForeignKey { get; }
        bool IsNullable { get; set; }
	}
}
