using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancesManager.Operations.Application.Responses
{
    public class OperationResponse
    {
        public Guid UserId { get; set; }
        public bool Earning { get; set; }
        public DateTime EffectedDate { get; set; }
        public float Ammount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Categories { get; set; } = String.Empty;
    }
}
