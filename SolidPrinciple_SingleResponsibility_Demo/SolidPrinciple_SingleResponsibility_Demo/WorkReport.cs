using SolidPrinciple_SingleResponsibility_Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciple_SingleResponsibility_Demo
{
    public class WorkReport
    {
        private readonly List<WorkReportEntry> _entries; //list of WorkReportEntry objects
        public WorkReport()
        {
            _entries= new List<WorkReportEntry>();
        }
        public void AddEntry(WorkReportEntry entry)
        {
            _entries.Add(entry);
        }
        public void RemoveEntryAt(int index)
        {
            _entries.RemoveAt(index);
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, _entries.Select(x => $"Code: {x.ProjectCode}, Name: {x.ProjectName}, Hours: {x.SpentHours}"));
        }
    }
    public class FileSaver
    {
        public void SaveToFile(string directoryPath, string fileName, WorkReport report)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            File.WriteAllText(Path.Combine(directoryPath, fileName), report.ToString());
        }
    }
}

