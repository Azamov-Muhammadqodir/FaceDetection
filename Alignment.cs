
using FaceAiSharp;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;


public class Alignment
{
    public static async Task<float[]> Start()
    {
        //using var hc = new HttpClient();
        //var groupPhoto = await hc.GetByteArrayAsync(
        //    "https://raw.githubusercontent.com/georg-jung/FaceAiSharp/master/examples/obama_family.jpg");


        var img = Image.Load<Rgb24>("D:\\TestProjects\\OqsTools\\FaceRecoganize\\Recources\\Muhammadqodir.jpg");

        var det = FaceAiSharpBundleFactory.CreateFaceDetectorWithLandmarks();
        var rec = FaceAiSharpBundleFactory.CreateFaceEmbeddingsGenerator();

        var faces = det.DetectFaces(img);
        var face = faces.First();
        rec.AlignFaceUsingLandmarks(img, face.Landmarks);
        var embedd =  rec.GenerateEmbedding(img);
        return embedd;
        //img.Save("aligned.jpg");
    }
}
