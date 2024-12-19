namespace TumakovLab9.Classes
{
    // Домашнее задание 9.1 В класс Song (из домашнего задания 8.2) добавить следующие конструкторы:
    // 1) параметры конструктора – название и автор песни, указатель на предыдущую песню инициализировать null.
    // 2) параметры конструктора – название, автор песни, предыдущая песня.
    public class Song
    {
        public string Name { get; set; } 
        public string Author { get; set; } 
        public Song Prev { get; set; } 
        
        public Song(string name, string author)
        {
            Name = name;
            Author = author;
            Prev = null;
        }
        public Song(string name, string author, Song previousSong)
        {
            Name = name;
            Author = author;
            Prev = previousSong;
        }
        
        public Song()
        {
            Name = string.Empty;
            Author = string.Empty;
            Prev = null;
        }

        public void Print()
        {
            Console.WriteLine($"{Name} - {Author}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Song other = (Song)obj;
            return Name == other.Name && Author == other.Author;
        }
    }

}




