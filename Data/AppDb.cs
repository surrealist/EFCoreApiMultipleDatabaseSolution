using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Data
{
  public class AppDb : DbContext
  {

    public AppDb(DbContextOptions<AppDb> options) : base(options)
    {

    }
  }
}
