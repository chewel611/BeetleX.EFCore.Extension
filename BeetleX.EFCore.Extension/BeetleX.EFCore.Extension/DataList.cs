﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeetleX.EFCore.Extension
{
    public class DBObjectList<T> : List<T> where T : new()
    {

        public static implicit operator DBObjectList<T>(ValueTuple<DbContext, string, Region> context)
        {
            DBObjectList<T> result = new DBObjectList<T>();
            var items = ((SQL)context.Item2).List<T>(context.Item1, context.Item3);
            result.AddRange(items);
            return result;
        }

        public static implicit operator DBObjectList<T>(ValueTuple<DbContext, string> context)
        {
            DBObjectList<T> result = new DBObjectList<T>();
            var items = ((SQL)context.Item2).List<T>(context.Item1);
            result.AddRange(items);
            return result;
        }


        public static implicit operator DBObjectList<T>(ValueTuple<DbContext, SQL, Region> context)
        {
            DBObjectList<T> result = new DBObjectList<T>();
            var items = context.Item2.List<T>(context.Item1, context.Item3);
            result.AddRange(items);
            return result;
        }

        public static implicit operator DBObjectList<T>(ValueTuple<DbContext, SQL> context)
        {
            DBObjectList<T> result = new DBObjectList<T>();
            var items = context.Item2.List<T>(context.Item1);
            result.AddRange(items);
            return result;
        }

        public static implicit operator DBObjectList<T>(ValueTuple<DbContext, Select<T>, Region> context)
        {
            DBObjectList<T> result = new DBObjectList<T>();
            var items = context.Item2.List(context.Item1, context.Item3);
            result.AddRange(items);
            return result;
        }

        public static implicit operator DBObjectList<T>(ValueTuple<DbContext, Select<T>> context)
        {
            DBObjectList<T> result = new DBObjectList<T>();
            var items = context.Item2.List(context.Item1);
            result.AddRange(items);
            return result;
        }
    }

    public class DBValueList<T> : List<T>
    {

        public static implicit operator DBValueList<T>(ValueTuple<DbContext, string> context)
        {
            DBValueList<T> result = new DBValueList<T>();
            ((SQL)context.Item2).List(context.Item1, null, r =>
            {
                if (r[0] != DBNull.Value)
                    result.Add((T)r[0]);
                else
                    result.Add(default(T));
            });
            return result;
        }

        public static implicit operator DBValueList<T>(ValueTuple<DbContext, SQL> context)
        {
            DBValueList<T> result = new DBValueList<T>();
            context.Item2.List(context.Item1, null, r =>
            {
                if (r[0] != DBNull.Value)
                    result.Add((T)r[0]);
                else
                    result.Add(default(T));
            });
            return result;
        }

        public static implicit operator DBValueList<T>(ValueTuple<DbContext, string, Region> context)
        {
            DBValueList<T> result = new DBValueList<T>();
            ((SQL)context.Item2).List(context.Item1, context.Item3, r =>
            {
                if (r[0] != DBNull.Value)
                    result.Add((T)r[0]);
                else
                    result.Add(default(T));
            });
            return result;
        }

        public static implicit operator DBValueList<T>(ValueTuple<DbContext, SQL, Region> context)
        {
            DBValueList<T> result = new DBValueList<T>();
            context.Item2.List(context.Item1, context.Item3, r =>
            {
                if (r[0] != DBNull.Value)
                    result.Add((T)r[0]);
                else
                    result.Add(default(T));
            });
            return result;
        }
    }

    public struct DBExecute
    {

        public int Count { get; set; }

        public static implicit operator DBExecute(ValueTuple<DbContext, string, string, string, string, string> context)
        {
            DBExecute result = new DBExecute();
            result.Count += ((SQL)context.Item2).Execute(context.Item1);
            result.Count += ((SQL)context.Item3).Execute(context.Item1);
            result.Count += ((SQL)context.Item4).Execute(context.Item1);
            result.Count += ((SQL)context.Item5).Execute(context.Item1);
            result.Count += ((SQL)context.Item6).Execute(context.Item1);
            return result;
        }

        public static implicit operator DBExecute(ValueTuple<DbContext, string, string, string, string> context)
        {
            DBExecute result = new DBExecute();
            result.Count += ((SQL)context.Item2).Execute(context.Item1);
            result.Count += ((SQL)context.Item3).Execute(context.Item1);
            result.Count += ((SQL)context.Item4).Execute(context.Item1);
            result.Count += ((SQL)context.Item5).Execute(context.Item1);
            return result;
        }

        public static implicit operator DBExecute(ValueTuple<DbContext, string, string, string> context)
        {
            DBExecute result = new DBExecute();
            result.Count += ((SQL)context.Item2).Execute(context.Item1);
            result.Count += ((SQL)context.Item3).Execute(context.Item1);
            result.Count += ((SQL)context.Item4).Execute(context.Item1);
            return result;
        }

        public static implicit operator DBExecute(ValueTuple<DbContext, string, string> context)
        {
            DBExecute result = new DBExecute();
            result.Count += ((SQL)context.Item2).Execute(context.Item1);
            result.Count += ((SQL)context.Item3).Execute(context.Item1);
            return result;
        }

        public static implicit operator DBExecute(ValueTuple<DbContext, string> context)
        {
            DBExecute result = new DBExecute();
            result.Count += ((SQL)context.Item2).Execute(context.Item1);
            return result;
        }

        public static implicit operator DBExecute(ValueTuple<DbContext, SQL, SQL, SQL, SQL, SQL> context)
        {
            DBExecute result = new DBExecute();
            result.Count += context.Item2.Execute(context.Item1);
            result.Count += context.Item3.Execute(context.Item1);
            result.Count += context.Item4.Execute(context.Item1);
            result.Count += context.Item5.Execute(context.Item1);
            result.Count += context.Item6.Execute(context.Item1);
            return result;
        }

        public static implicit operator DBExecute(ValueTuple<DbContext, SQL, SQL, SQL, SQL> context)
        {
            DBExecute result = new DBExecute();
            result.Count += context.Item2.Execute(context.Item1);
            result.Count += context.Item3.Execute(context.Item1);
            result.Count += context.Item4.Execute(context.Item1);
            result.Count += context.Item5.Execute(context.Item1);
            return result;
        }

        public static implicit operator DBExecute(ValueTuple<DbContext, SQL, SQL, SQL> context)
        {
            DBExecute result = new DBExecute();
            result.Count += context.Item2.Execute(context.Item1);
            result.Count += context.Item3.Execute(context.Item1);
            result.Count += context.Item4.Execute(context.Item1);
            return result;
        }

        public static implicit operator DBExecute(ValueTuple<DbContext, SQL, SQL> context)
        {
            DBExecute result = new DBExecute();
            result.Count += context.Item2.Execute(context.Item1);
            result.Count += context.Item3.Execute(context.Item1);
            return result;
        }

        public static implicit operator DBExecute(ValueTuple<DbContext, SQL> context)
        {
            DBExecute result = new DBExecute();
            result.Count += context.Item2.Execute(context.Item1);
            return result;
        }
    }


    public struct DBExecute<T>
    {
        public T Value { get; set; }

        public static implicit operator DBExecute<T>(ValueTuple<DbContext, string> context)
        {
            DBExecute<T> result = new DBExecute<T>();
            result.Value = ((SQL)context.Item2).ExecuteScalar<T>(context.Item1);
            return result;
        }

        public static implicit operator DBExecute<T>(ValueTuple<DbContext, SQL> context)
        {
            DBExecute<T> result = new DBExecute<T>();
            result.Value = context.Item2.ExecuteScalar<T>(context.Item1);
            return result;
        }
    }


}
