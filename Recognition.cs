using FaceAiSharp;
using SixLabors.ImageSharp.PixelFormats;

public  class Recognition
{
    public static async Task Start(string path1, string path2)
    {
        var det = FaceAiSharpBundleFactory.CreateFaceDetectorWithLandmarks();
        var rec = FaceAiSharpBundleFactory.CreateFaceEmbeddingsGenerator();


        var img1 = SixLabors.ImageSharp.Image.Load<Rgb24>(path1);
        var img2 = SixLabors.ImageSharp.Image.Load<Rgb24>(path2);

        var face1 = det.DetectFaces(img1).FirstOrDefault();
        var face2 = det.DetectFaces(img2).FirstOrDefault();

        rec.AlignFaceUsingLandmarks(img1, face1.Landmarks!);
        rec.AlignFaceUsingLandmarks(img2, face2.Landmarks!);

        var embedding1 = rec.GenerateEmbedding(img1);
        var embedding2 = rec.GenerateEmbedding(img2);

        var dot = FaceAiSharp.Extensions.GeometryExtensions.Dot(embedding1, embedding2);

        Console.WriteLine($"Dot product: {dot}");
        if (dot >= 0.42)
        {
            Console.WriteLine("Ikkalasi o'xshash");
        }
        else if (dot > 0.28 && dot < 0.42)
        {
            Console.WriteLine("O'xshashlik kam");
        }
        else if (dot <= 0.28)
        {
            Console.WriteLine("o'xshash emas");
        }
    }
}

