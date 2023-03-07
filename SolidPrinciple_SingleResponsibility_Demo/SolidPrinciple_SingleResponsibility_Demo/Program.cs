// See https://aka.ms/new-console-template for more information
using SolidPrinciple_SingleResponsibility_Demo;
//var report = new WorkReport();
//report.AddEntry(new WorkReportEntry { ProjectCode = "123Ds", ProjectName = "Project1", SpentHours = 5 });
//report.AddEntry(new WorkReportEntry { ProjectCode = "987Fc", ProjectName = "Project2", SpentHours = 3 });
//Console.WriteLine(report.ToString());
////var saver = new FileSaver();
////saver.SaveToFile(@"Reports", "WorkReport.txt", report);
//report.AddEntry(new WorkReportEntry { ProjectCode = "58544h", ProjectName = "Project3", SpentHours = 1 }); 
//report.AddEntry(new WorkReportEntry { ProjectCode = "78opuji", ProjectName = "Project4", SpentHours = 4 });
//var saver1 = new FileSaver();
//Console.WriteLine(report.ToString());
//report.RemoveEntryAt(0);
////report.RemoveEntryAt(2);
////report.RemoveEntryAt();
//report.RemoveEntryAt(1);

//var saver2 = new FileSaver();
//Console.WriteLine(report.ToString());
//saver2.SaveToFile(@"Reports", "WorkReport.txt", report);



var report = new WorkReport();
report.AddEntry(new WorkReportEntry { ProjectCode = "123Ds", ProjectName = "Project1", SpentHours = 5 });
report.AddEntry(new WorkReportEntry { ProjectCode = "987Fc", ProjectName = "Project2", SpentHours = 3 });
Console.WriteLine(report.ToString());
var saver = new FileSaver();
saver.SaveToFile(@"Reports", "WorkReport.txt", report);