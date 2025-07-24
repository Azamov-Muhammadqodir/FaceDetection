//await Alignment.Start();





string path = "C:\\Users\\Muhammadqodir\\OneDrive\\Desktop";
string path1 = Path.Combine(path, "photo1.jpg");
string path2 = Path.Combine(path, "photo3.jpg");
await Recognition.Start(path1, path2);
