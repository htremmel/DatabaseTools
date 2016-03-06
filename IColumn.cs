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
	public interface IColumn<T> where T : Type
	{
		string Name { get; set; }
		DbType Type { get; }
        Type SystemType { get; }
		int Order { get; }
		ITable<T> Parent { get; }
        bool IsKey { get; }
        bool IsForeignKey { get; }
	}
}
