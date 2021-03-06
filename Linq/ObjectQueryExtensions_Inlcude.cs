﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Linq.Expressions;
//using System.Reflection;
//using System.Runtime.CompilerServices;
//using System.Data.Objects; // System.Data.Entity

//namespace Help.Linqs
//{
//	/// <summary>
//	/// ObjectQueryExtensions
//	/// </summary>
//	public static class HelperObjectQueryExtensions
//	{
//		/// <summary>
//		/// Include
//		/// </summary>
//		/// <typeparam name="T"></typeparam>
//		/// <param name="query"></param>
//		/// <param name="selector"></param>
//		/// <returns></returns>
//		public static ObjectQuery<T> Include<T>( this ObjectQuery<T> query, Expression<Func<T, object>> selector )
//		{
//			string path = new PropertyPathVisitor( ).GetPropertyPath( selector );
//			return query.Include( path );
//		}

//		public static string Translate<T>( this ObjectQuery<T> query, Expression<Func<T, object>> selector )
//		{
//			string path = new PropertyPathVisitor( ).GetPropertyPath( selector );
//			return ( path );
//		}

//		/// <summary>
//		/// PropertyPathVisitor 
//		/// </summary>
//		class PropertyPathVisitor : ExpressionVisitor
//		{
//			private Stack<string> _stack;

//			public string GetPropertyPath( Expression expression )
//			{
//				_stack = new Stack<string>( );
//				Visit( expression );
//				return _stack
//					.Aggregate(
//						new StringBuilder( ),
//						( sb, name ) =>
//							( sb.Length > 0 ? sb.Append( "." ) : sb ).Append( name ) )
//					.ToString( );
//			}

//			protected override Expression VisitMember( MemberExpression expression )
//			{
//				if( _stack != null )
//					_stack.Push( expression.Member.Name );
//				return base.VisitMember( expression );
//			}

//			protected override Expression VisitMethodCall( MethodCallExpression expression )
//			{
//				if( IsLinqOperator( expression.Method ) ) {
//					for( int i = 1; i < expression.Arguments.Count; i++ ) {
//						Visit( expression.Arguments[ i ] );
//					}
//					Visit( expression.Arguments[ 0 ] );
//					return expression;
//				}
//				return base.VisitMethodCall( expression );
//			}

//			private static bool IsLinqOperator( MethodInfo method )
//			{
//				if( method.DeclaringType != typeof( Queryable ) && method.DeclaringType != typeof( Enumerable ) )
//					return false;
//				return Attribute.GetCustomAttribute( method, typeof( ExtensionAttribute ) ) != null;
//			}
//		}
//	}
//}
