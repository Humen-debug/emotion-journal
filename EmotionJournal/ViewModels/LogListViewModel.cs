using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EmotionJournal.ViewModels;

public class LogListViewModel: ObservableObject
{
    public ObservableCollection<LogViewModel> Logs { get; set; }

    public LogListViewModel() => Logs = [];

    public async Task RefreshLogs(){
        
    }

    public void AddLog(LogViewModel log) => Logs.Add(log);
    public void DeleteLog(LogViewModel log) => Logs.Remove(log);
    
}
