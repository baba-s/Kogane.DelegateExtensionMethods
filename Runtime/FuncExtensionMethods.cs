﻿using System;
using System.Linq;

namespace Kogane
{
    /// <summary>
    /// Func 型の拡張メソッドを管理するクラス
    /// </summary>
    public static class FuncExtensionMethods
    {
        //================================================================================
        // 関数(static)
        //================================================================================
        /// <summary>
        /// パラメーターを受け取らずに戻り値を返す Func デリゲートを実行します
        /// </summary>
        public static TResult Call<TResult>( this Func<TResult> self )
        {
            return self.Call( default );
        }

        /// <summary>
        /// パラメーターを受け取らずに戻り値を返す Func デリゲートを実行します
        /// </summary>
        public static TResult Call<TResult>( this Func<TResult> self, TResult result )
        {
            return self != null ? self() : result;
        }

        /// <summary>
        /// 1 つのパラメーターを受け取って戻り値を返す Func デリゲートを実行します
        /// </summary>
        public static TResult Call<T, TResult>( this Func<T, TResult> self, T arg )
        {
            return self.Call( arg, default );
        }

        /// <summary>
        /// 1 つのパラメーターを受け取って戻り値を返す Func デリゲートを実行します
        /// </summary>
        public static TResult Call<T, TResult>
        (
            this Func<T, TResult> self,
            T                     arg,
            TResult               result
        )
        {
            return self != null ? self( arg ) : result;
        }

        /// <summary>
        /// 2 つのパラメーターを受け取って戻り値を返す Func デリゲートを実行します
        /// </summary>
        public static TResult Call<T1, T2, TResult>
        (
            this Func<T1, T2, TResult> self,
            T1                         arg1,
            T2                         arg2
        )
        {
            return self.Call( arg1, arg2, default );
        }

        /// <summary>
        /// 2 つのパラメーターを受け取って戻り値を返す Func デリゲートを実行します
        /// </summary>
        public static TResult Call<T1, T2, TResult>
        (
            this Func<T1, T2, TResult> self,
            T1                         arg1,
            T2                         arg2,
            TResult                    result
        )
        {
            return self != null ? self( arg1, arg2 ) : result;
        }

        /// <summary>
        /// 3 つのパラメーターを受け取って戻り値を返す Func デリゲートを実行します
        /// </summary>
        public static TResult Call<T1, T2, T3, TResult>
        (
            this Func<T1, T2, T3, TResult> self,
            T1                             arg1,
            T2                             arg2,
            T3                             arg3
        )
        {
            return self.Call( arg1, arg2, arg3, default );
        }

        /// <summary>
        /// 3 つのパラメーターを受け取って戻り値を返す Func デリゲートを実行します
        /// </summary>
        public static TResult Call<T1, T2, T3, TResult>
        (
            this Func<T1, T2, T3, TResult> self,
            T1                             arg1,
            T2                             arg2,
            T3                             arg3,
            TResult                        result
        )
        {
            return self != null ? self( arg1, arg2, arg3 ) : result;
        }

        /// <summary>
        /// 登録されているすべてのデリゲートが true を返す場合 true を返します
        /// </summary>
        public static bool All( this Func<bool> self )
        {
            return self
                    .GetInvocationList()
                    .All( x => ( bool )x.DynamicInvoke() )
                ;
        }

        /// <summary>
        /// 登録されているすべてのデリゲートが true を返す場合 true を返します
        /// </summary>
        public static bool All<T>( this Func<T, bool> self, T arg )
        {
            return self
                    .GetInvocationList()
                    .All( x => ( bool )x.DynamicInvoke( arg ) )
                ;
        }

        /// <summary>
        /// 登録されているすべてのデリゲートが true を返す場合 true を返します
        /// </summary>
        public static bool All<T1, T2>
        (
            this Func<T1, T2, bool> self,
            T1                      arg1,
            T2                      arg2
        )
        {
            return self
                    .GetInvocationList()
                    .All( x => ( bool )x.DynamicInvoke( arg1, arg2 ) )
                ;
        }

        /// <summary>
        /// 登録されているすべてのデリゲートが true を返す場合 true を返します
        /// </summary>
        public static bool All<T1, T2, T3>
        (
            this Func<T1, T2, T3, bool> self,
            T1                          arg1,
            T2                          arg2,
            T3                          arg3
        )
        {
            return self
                    .GetInvocationList()
                    .All( x => ( bool )x.DynamicInvoke( arg1, arg2, arg3 ) )
                ;
        }

        /// <summary>
        /// 登録されているいずれかのデリゲートが true を返す場合 true を返します
        /// </summary>
        public static bool Any( this Func<bool> self )
        {
            return self
                    .GetInvocationList()
                    .Any( x => ( bool )x.DynamicInvoke() )
                ;
        }

        /// <summary>
        /// 登録されているいずれかのデリゲートが true を返す場合 true を返します
        /// </summary>
        public static bool Any<T>( this Func<T, bool> self, T arg )
        {
            return self
                    .GetInvocationList()
                    .Any( x => ( bool )x.DynamicInvoke( arg ) )
                ;
        }

        /// <summary>
        /// 登録されているいずれかのデリゲートが true を返す場合 true を返します
        /// </summary>
        public static bool Any<T1, T2>
        (
            this Func<T1, T2, bool> self,
            T1                      arg1,
            T2                      arg2
        )
        {
            return self
                    .GetInvocationList()
                    .Any( x => ( bool )x.DynamicInvoke( arg1, arg2 ) )
                ;
        }

        /// <summary>
        /// 登録されているいずれかのデリゲートが true を返す場合 true を返します
        /// </summary>
        public static bool Any<T1, T2, T3>
        (
            this Func<T1, T2, T3, bool> self,
            T1                          arg1,
            T2                          arg2,
            T3                          arg3
        )
        {
            return self
                    .GetInvocationList()
                    .Any( x => ( bool )x.DynamicInvoke( arg1, arg2, arg3 ) )
                ;
        }

        public static TResult CallOrDefault<TResult>
        (
            this Func<TResult> self,
            Func<TResult>      defaultValue
        )
        {
            return self != null ? self() : defaultValue();
        }

        public static TResult CallOrDefault<T, TResult>
        (
            this Func<T, TResult> self,
            T                     arg,
            Func<T, TResult>      defaultValue
        )
        {
            return self != null ? self( arg ) : defaultValue( arg );
        }

        public static TResult CallOrDefault<T1, T2, TResult>
        (
            this Func<T1, T2, TResult> self,
            T1                         arg1,
            T2                         arg2,
            Func<T1, T2, TResult>      defaultValue
        )
        {
            return self != null ? self( arg1, arg2 ) : defaultValue( arg1, arg2 );
        }

        public static TResult CallOrDefault<T1, T2, T3, TResult>
        (
            this Func<T1, T2, T3, TResult> self,
            T1                             arg1,
            T2                             arg2,
            T3                             arg3,
            Func<T1, T2, T3, TResult>      defaultValue
        )
        {
            return self != null ? self( arg1, arg2, arg3 ) : defaultValue( arg1, arg2, arg3 );
        }
    }
}