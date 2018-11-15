using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianceAssociationBank.Crm.Reports
{
    public interface IReport
    {
        ReportViewer ReportViewer { get; }
        Task ExecuteReport();
    }
}
