using FinancesManager.Operations.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesManager.Operations.Infrastructure.Data
{
    public class OperationContext:DbContext
    {
        public OperationContext() { }
        public OperationContext(DbContextOptions<OperationContext> options) : base(options) { }
        public virtual DbSet<Operation> Operations
        {
            get;
            set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //                optionsBuilder.UseSqlServer("Data Source=EN911521\\SQLEXPRESS;Initial Catalog=Book;Integrated Security=True;");
            //            }
        }

    }
}
