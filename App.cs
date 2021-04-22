using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Data;

namespace WebApplication5
{
  public class App : IDisposable
  {
    public AppDb Db { get; set; }
    public string ConnectionString { get; set; }

    public void Dispose()
    {
      Db?.Dispose();
    }
  }
}
