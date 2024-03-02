using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditTransferSystem.Domain.Models
{
    public class TransferredCredits
    {
        public string StateOrTerritory { get; set; }
        public string InstitutionName { get; set; }
        public string ProgramType { get; set; }
        public bool Graduated { get; set; }
    }
}
