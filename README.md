# UniDelegateExtensionMethods

Action、Func、MulticastDelegate 型の拡張メソッド

## Action

### Call

```cs
using System;
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Awake()
    {
        Action                action0 = null;
        Action<int>           action1 = null;
        Action<int, int>      action2 = null;
        Action<int, int, int> action3 = null;
        
        action0.Call();
        action1.Call( 1 );
        action2.Call( 1, 2 );
        action3.Call( 1, 2, 3 );
        
        // 下記のコードと同様
        //action0?.Invoke();
        //action1?.Invoke( 1 );
        //action2?.Invoke( 1, 2 );
        //action3?.Invoke( 1, 2, 3 );
    }
}
```

### CallOrDefault

```cs
using System;
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Awake()
    {
        Action           action0 = null;
        Action<int>      action1 = null;
        Action<int, int> action2 = null;
        
        // Action が null であれば引数の最後に渡したコールバックが代わりに呼び出されます
        action0.CallOrDefault( () => Debug.Log( "ピカチュウ" ));
        action1.CallOrDefault( 1, () => Debug.Log( "ピカチュウ"  ));
        action2.CallOrDefault( 1, 2, () => Debug.Log( "ピカチュウ" ) );
    }
}
```

## Func

### Call

```cs
using Kogane;
using System;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Awake()
    {
        Func<bool>           func0 = null;
        Func<int, bool>      func1 = null;
        Func<int, int, bool> func2 = null;

        var result10 = func0.Call();
        var result11 = func1.Call( 1 );
        var result12 = func2.Call( 1, 2 );
        
        // 下記のコードと同様
        //var result0 = func0?.Invoke();
        //var result1 = func1?.Invoke( 1 );
        //var result2 = func2?.Invoke( 1, 2 );
        
        var result20 = func0.Call( true );
        var result21 = func1.Call( 1, true );
        var result22 = func2.Call( 1, 2, true );
        
        // 下記のコードと同様
        //var result20 = func0 != null ? func0() : true;
        //var result21 = func1 != null ? func1( 1 ) : true;
        //var result22 = func2 != null ? func2( 1, 2 ) : true;
    }
}
```

### All

```cs
using Kogane;
using System;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Awake()
    {
        Func<bool> func = null;
        func += () => true;
        func += () => true;
        func += () => false;

        // Func デリゲートに登録されている
        // すべてのコールバックが true を返す場合 true
        var result = func.All(); // False
    }
}
```

### Any

```cs
using Kogane;
using System;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Awake()
    {
        Func<bool> func = null;
        func += () => true;
        func += () => true;
        func += () => false;

        // Func デリゲートに登録されている
        // いずれかのコールバックが true を返す場合 true
        var result = func.Any(); // True
    }
}
```

## MulticastDelegate

### GetLength, GetLengthIfNotNull

```cs
using Kogane;
using System;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Awake()
    {
        Action action = null;
        action += () => { };
        action += () => { };
        action += () => { };

        // 登録されているコールバックの数を取得します
        Debug.Log( action.GetLength() ); // 3
        Debug.Log( action.GetLengthIfNotNull() ); // 3
    }
}
```

### IsNullOrEmpty, IsNotNullOrEmpty

```cs
using Kogane;
using System;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Awake()
    {
        Action action = null;
        action += () => { };
        action += () => { };
        action += () => { };

        // null もしくはコールバックが登録されていない場合 true を取得します
        Debug.Log( action.IsNullOrEmpty() ); // False

        // null ではなく、かつコールバックが登録されている場合 true を取得します
        Debug.Log( action.IsNotNullOrEmpty() ); // True
    }
}
```
