using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения (*.jpg)|*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                Stream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                StrokeCollection strokes = new StrokeCollection(fileStream);
                paint.Strokes = strokes;
                /*Image myImage = new Image();
                myImage.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                paint.Children.Add(myImage);*/
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Изображения (*.jpg)|*.jpg";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream file = new FileStream(saveFileDialog.FileName, FileMode.Create);
                paint.Strokes.Save(file);
                MessageBox.Show("Файл сохранен");
                /*using (FileStream file = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    int marg = int.Parse(paint.Margin.Left.ToString());
                    RenderTargetBitmap rtb = new RenderTargetBitmap((int)paint.ActualWidth - marg, (int)paint.ActualHeight - marg, 0, 0, PixelFormats.Default);
                    rtb.Render(paint);
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(rtb));
                    encoder.Save(file);
                    file.Close();
                    MessageBox.Show("Файл сохранен");
                }*/
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (paint != null)
            {
                paint.EditingMode = InkCanvasEditingMode.Ink;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (paint != null)
            {
                paint.EditingMode = InkCanvasEditingMode.EraseByPoint;
            }
        }
    }
}
