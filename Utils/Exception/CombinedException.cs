using System.Collections.Generic;
using System.Linq;

namespace Common.Lib.Utils.Exception
{
  public class CombinedException : System.Exception
  {
    /// <summary>
    /// 	Initializes a new instance of the <see cref = "CombinedException" /> class.
    /// </summary>
    /// <param name = "message">The message.</param>
    /// <param name = "innerExceptions">The inner exceptions.</param>
    public CombinedException(string message, System.Exception[] innerExceptions)
      : base(message)
    {
      InnerExceptions = innerExceptions;
    }

    /// <summary>
    /// 	Gets the inner exceptions.
    /// </summary>
    /// <value>The inner exceptions.</value>
    public System.Exception[] InnerExceptions { get; protected set; }

    public static System.Exception Combine(string message, params System.Exception[] innerExceptions)
    {
      if (innerExceptions.Length == 1)
        return innerExceptions[0];

      return new CombinedException(message, innerExceptions);
    }
    /// <summary>
    /// Combines the specified exception.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="innerExceptions">The inner exceptions.</param>
    /// <returns></returns>
    public static System.Exception Combine(string message, IEnumerable<System.Exception> innerExceptions)
    {
      return Combine(message, innerExceptions.ToArray());
    }
  }
}
