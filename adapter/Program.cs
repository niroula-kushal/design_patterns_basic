// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var api = new GithubApi();
var ghUsers = api.GetUsers();

var exporter = new UserListExporter();
List<User> users = [
    new User()
    {
        Id = 1,
        Name = "Something",
        Role = "SOmething"
    }
];
exporter.ExportUserList(users);

var adapter = new GithubUserExportAdapter(exporter);

// var exported = adapter.ExportUserList(ghUsers, exporter);

AudioPlayer player = new AudioPlayerAdapter();
player.Play("mp3", "user.mp3");


public class GithubApi
{
    public List<GithubUser> GetUsers()
    {
        return [
            new GithubUser()
            {
                Id = 1,
                Contact = "safd",
                Name = "hola",
                FollowerCount = 90
            }
        ];
    }
}

public class GithubUser
{
    public string Name { get;set; }
    public string Contact { get; set; }
    public int Id { get; set; }
    public int FollowerCount { get; set; }
}

public class UserListExporter
{
    public string ExportUserList(List<User> users)
    {
        return "exported users";
    }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
}

public class GithubUserExportAdapter
{
    private readonly UserListExporter listExporter;

    public GithubUserExportAdapter(UserListExporter listExporter)
    {
        this.listExporter = listExporter;
    }
    public string ExportUserList(List<GithubUser> ghUsers)
    {
        var normalUsers = ghUsers.Select(x => new User()
        {
            Id = x.Id,
            Name = x.Name,
            Role = "N/A"
        }).ToList();
        return listExporter.ExportUserList(normalUsers);
    }
}



public class OldAudioPlayer {
    public void PlayMp3(string filename) {
        Console.WriteLine ("Playing MP3 file: " + filename);
    }
}

public interface AudioPlayer {
    void Play(string audioType, string filename);
}

public class AudioPlayerAdapter : AudioPlayer
{
    public void Play(string audioType, string filename)
    {
        if(audioType == "mp3")
        {
            var player = new OldAudioPlayer();
            player.PlayMp3(filename);
        }
        else
        {
            Console.WriteLine("Invalid audio type: " + audioType);
        }
    }
}