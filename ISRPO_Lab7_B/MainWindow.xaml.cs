using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISRPO_Lab7_B
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DropShadowEffect dropShadowEffect = new DropShadowEffect() { Color = Color.FromRgb(255, 255, 0), ShadowDepth = 0, BlurRadius = 50 };
        UIElement selectedElement;

        public MainWindow()
        {
            InitializeComponent();

            //TransformGroup transformGroup = new TransformGroup();
            //transformGroup.Children.Add(new RotateTransform());
            //transformGroup.Children.Add(new ScaleTransform());
            //transformGroup.Children.Add(new TranslateTransform());
            //polygon.RenderTransform = transformGroup;

            selectedElement = polygon;
            polygon.Effect = dropShadowEffect;
        }

        double mouseX = 0;
        double mouseY = 0;

        double mouseXSpeed = 0;
        double mouseYSpeed = 0;

        enum Action
        {
            None, Rotate, Scale, Translate
        }

        Action action = Action.None;

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            mouseXSpeed = e.GetPosition(this).X - mouseX;
            mouseYSpeed = e.GetPosition(this).Y - mouseY;

            mouseX = e.GetPosition(this).X;
            mouseY = e.GetPosition(this).Y;

            switch (action)
            {
                case Action.Rotate:
                    ((selectedElement.RenderTransform as TransformGroup).Children[0] as RotateTransform).Angle += mouseXSpeed;
                    break;
                case Action.Scale:
                    ((selectedElement.RenderTransform as TransformGroup).Children[1] as ScaleTransform).ScaleX += mouseXSpeed / 100.0;
                    ((selectedElement.RenderTransform as TransformGroup).Children[1] as ScaleTransform).ScaleY += mouseXSpeed / 100.0;
                    break;
                case Action.Translate:
                    ((selectedElement.RenderTransform as TransformGroup).Children[2] as TranslateTransform).X += mouseXSpeed;
                    ((selectedElement.RenderTransform as TransformGroup).Children[2] as TranslateTransform).Y += mouseYSpeed;
                    break;
            }
        }
     

        private void BtnTranslate_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            action = Action.Translate;
        }

        private void Btn_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            
            action = Action.None;
        }

        private void BtnRotate_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            action = Action.Rotate;
        }

        private void BtnScale_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            action = Action.Scale;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedElement = image;
            foreach (UIElement child in dockPanel.Children) { child.Effect = null; }
            image.Effect = dropShadowEffect;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedElement = rectangle;
            foreach (UIElement child in dockPanel.Children) { child.Effect = null; }
            rectangle.Effect = dropShadowEffect;
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedElement = ellipse;
            foreach (UIElement child in dockPanel.Children) { child.Effect = null; }
            ellipse.Effect = dropShadowEffect;
        }

        private void Line_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedElement = line;
            foreach (UIElement child in dockPanel.Children) { child.Effect = null; }
            line.Effect = dropShadowEffect;
        }

        private void Polygon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            selectedElement = polygon;
            foreach (UIElement child in dockPanel.Children) { child.Effect = null; }
            polygon.Effect = dropShadowEffect;
        }
    }
}
