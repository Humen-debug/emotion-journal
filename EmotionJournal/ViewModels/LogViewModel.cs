using CommunityToolkit.Mvvm.ComponentModel;

namespace EmotionJournal.ViewModels;

public class LogViewModel: ObservableObject
{
    private string _title;
    private string _content;
    private DateTime _createdDate;
    private DateTime _lastModifiedDate;

    public string Title {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public string Content {
        get => _content;
        set => SetProperty(ref _content, value);
    }

    public DateTime CreatedDate {
        get => _createdDate;
    }

    public DateTime LastModifiedDate{
        get => _lastModifiedDate;
        set => SetProperty(ref _lastModifiedDate, value);
    }

    public LogViewModel(){
        _title = "";
        _content = "";
        _createdDate = new DateTime();
        _lastModifiedDate = new DateTime();
    }

    public LogViewModel(Models.Log log){
        _title = log.Title;
        _content = log.Content;
        
        if(log.CreatedDate is not null){
            _createdDate = DateTime.Parse(log.CreatedDate);
        }else{
            _createdDate = new DateTime();
        }

        if (log.LastModifiedDate is not null){
            _lastModifiedDate = DateTime.Parse(log.LastModifiedDate);
        }else{
            _lastModifiedDate = new DateTime();
        }

        
    }
}
