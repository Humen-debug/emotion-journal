namespace EmotionJournal.Models;

public record struct Log(
    string Title,
    string Content,
    string CreatedDate,
    string LastModifiedDate,
    int Mood
);
