/*
{
  "songName": "Believer",
  "songSubName": "Imagine Dragons",
  "authorName": "Rustic",
  "beatsPerMinute": 125,
  "previewStartTime": 12,
  "previewDuration": 10,
  "coverImagePath": "cover.jpg",
  "environmentName": "NiceEnvironment",
  "difficultyLevels": [
    {
      "difficulty": "Expert",
      "difficultyRank": 4,
      "audioPath": "song.ogg",
      "jsonPath": "Expert.json"
    }
  ]
}
 */
namespace BeatSaberModInstaller.Models.CustomSong
{
    public class CustomSong
    {
        public string SongName { get; set; }
        public string SongSubName { get; set; }
        public string AuthorName { get; set; }
        public int BeatsPerMinute { get; set; }
        public string CoverImagePath { get; set; }
//        public SongDifficultiesObject DifficultyLevels { get; set; }
    }
}