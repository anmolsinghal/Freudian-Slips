using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Emotion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace copiedApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        const string APIKey = "a9d48d5469ef4d04b480ba73115d4bf0";
        EmotionServiceClient emotionserviceclient = new EmotionServiceClient(APIKey);
        Emotion[] emotionresult;
        public MainPage()
        {
            this.InitializeComponent();
            BackButton_Click();
        }


        private async void BackButton_Click()
        {
            MediaCapture _mediaCapture = new MediaCapture();
            await _mediaCapture.InitializeAsync();
            double val_res = 0.0;
            double aro_res = 0.0;
            Dictionary<int, Tuple<double, double>> imageData =
               new Dictionary<int, Tuple<double, double>>();


            Dictionary<string, Tuple<double, double>> emoData =
           new Dictionary<string, Tuple<double, double>>();
            emoData.Add("Neutral", Tuple.Create(4.98, 3.91));
            emoData.Add("Sadness", Tuple.Create(2.33, 4.55));
            emoData.Add("Disgust", Tuple.Create(3.5, 6.32));
            emoData.Add("Anger", Tuple.Create(2.33, 8.46));
            emoData.Add("Surprise", Tuple.Create(2.87, 8.11));
            emoData.Add("Fear", Tuple.Create(2.11, 8.52));
            emoData.Add("Happiness", Tuple.Create(7.09, 8.52));
            imageData.Add(1, Tuple.Create(45.698, 56.948));
            imageData.Add(2, Tuple.Create(2.951, 80.254));
            imageData.Add(3, Tuple.Create(44.751, 46.579));
            imageData.Add(4, Tuple.Create(58.107, 41.844));
            imageData.Add(5, Tuple.Create(0.72, 92.402));
            imageData.Add(6, Tuple.Create(6.758, 78.315));
            imageData.Add(7, Tuple.Create(13.962, 72.308));
            imageData.Add(8, Tuple.Create(5.666, 81.855));
            imageData.Add(9, Tuple.Create(10.942, 68.792));
            imageData.Add(10, Tuple.Create(5.095, 60.461));
            imageData.Add(11, Tuple.Create(17.421, 79.824));
            imageData.Add(12, Tuple.Create(3.675, 83.936));
            imageData.Add(13, Tuple.Create(77.82, 13.285));
            imageData.Add(14, Tuple.Create(81.301, 27.56));
            imageData.Add(15, Tuple.Create(92.896, 32.971));
            imageData.Add(16, Tuple.Create(95.341, 20.78));
            imageData.Add(17, Tuple.Create(79.398, 20.647));
            imageData.Add(18, Tuple.Create(92.759, 18.212));
            imageData.Add(19, Tuple.Create(93.05, 16.782));
            imageData.Add(20, Tuple.Create(93.076, 24.758));
            imageData.Add(21, Tuple.Create(95.163, 29.304));
            imageData.Add(22, Tuple.Create(95.167, 8.46));
            imageData.Add(23, Tuple.Create(78.075, 35.561));
            imageData.Add(24, Tuple.Create(86.7, 11.621));
            imageData.Add(25, Tuple.Create(78.635, 20.068));
            imageData.Add(26, Tuple.Create(71.86, 59.58));
            imageData.Add(27, Tuple.Create(92.909, 22.847));
            imageData.Add(28, Tuple.Create(35.436, 55.342));
            imageData.Add(29, Tuple.Create(63.66, 45.324));
            imageData.Add(30, Tuple.Create(56.168, 16.541));




            for (int i = 1; i <= 3; i++)
            {
                textb.Text = "";
                pic.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/" + i + ".bmp"));

                await Task.Delay(TimeSpan.FromSeconds(2));

                ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();

                // a file to save a photo
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("Photo.jpg", CreationCollisionOption.ReplaceExisting);

                await _mediaCapture.CapturePhotoToStorageFileAsync(imgFormat, file);
                IRandomAccessStream imageStream = await file.OpenAsync(FileAccessMode.Read);

                double resul_val = 0.0;
                double resul_aro = 0.0;



                emotionresult = await emotionserviceclient.RecognizeAsync(imageStream.AsStream());
                if (emotionresult != null)
                {
                    try
                    {
                        var score = emotionresult[0].Scores;
                        double max = 0.0;
                        max = Math.Max(max, score.Anger);
                        max = Math.Max(max, score.Happiness);
                        max = Math.Max(max, score.Sadness);
                        max = Math.Max(max, score.Surprise);
                        max = Math.Max(max, score.Neutral);
                        max = Math.Max(max, score.Disgust);
                        max = Math.Max(max, score.Fear);
                        double[] emo = { score.Anger, score.Disgust, score.Fear, score.Happiness, score.Neutral, score.Surprise, score.Sadness };
                        if (max == emo[0])
                            textb.Text = "Your primary emotion is: Anger";
                        else
                        {
                            if (max == emo[1])
                                textb.Text = "Your primary emotion is: Disgust";
                            else
                            {
                                if (max == emo[2])
                                    textb.Text = "Your primary emotion is: Fear";
                                else
                                {
                                    if (max == emo[3])
                                        textb.Text = "Your primary emotion is: Happiness";
                                    else
                                    {
                                        if (max == emo[4])
                                            textb.Text = "Your primary emotion is: Neutral";
                                        else
                                        {
                                            if (max == emo[5])
                                                textb.Text = "Your primary emotion is: Surprise";
                                            else
                                                textb.Text = "Your primary emotion is: Sadness";
                                        }
                                    }
                                }
                            }
                        }




                        resul_val = (emoData["Anger"].Item1 * score.Anger +
                           emoData["Happiness"].Item1 * score.Happiness +
                           emoData["Sadness"].Item1 * score.Sadness +
                           emoData["Surprise"].Item1 * score.Surprise +
                           emoData["Neutral"].Item1 * score.Neutral +
                           emoData["Disgust"].Item1 * score.Disgust +
                            emoData["Fear"].Item1 * score.Fear) * 100 / 9;


                        resul_aro = (emoData["Anger"].Item2 * score.Anger +
                           emoData["Happiness"].Item2 * score.Happiness +
                           emoData["Sadness"].Item2 * score.Sadness +
                           emoData["Surprise"].Item2 * score.Surprise +
                           emoData["Neutral"].Item2 * score.Neutral +
                           emoData["Disgust"].Item2 * score.Disgust +
                           emoData["Fear"].Item2 * score.Fear) * 100 / 9;
                    }
                    catch (IndexOutOfRangeException) { textb.Text = "No face detected"; }


                    double val = imageData[i].Item1;
                    double aro = imageData[i].Item2;

                    val_res += (resul_val - val) / (30);
                    aro_res += (resul_aro - aro) / (30);



                    await Task.Delay(TimeSpan.FromSeconds(2));

                }

            }
            String ans = "";
            if (val_res < 35)
            {
                ans += "The quality of your response is normal";
            }
            else
            {
                if (val_res < 50)
                {
                    ans += "The quality of your response shows slight deviations from ideal values";
                }
                else
                    ans += "The quality of your response is highly deviated from ideal values";
            }
            if (aro_res < 35)
            {
                ans += "\nThe intensity of your response is normal";
            }
            else
            {
                if (aro_res < 50)
                {
                    ans += "\nThe intensity of your response shows slight deviations from ideal values";
                }
                else
                    ans += "\nThe intensity of your response is highly deviated from ideal values";
            }

            Frame.Navigate(typeof(result), ans);
        }
    }
}

