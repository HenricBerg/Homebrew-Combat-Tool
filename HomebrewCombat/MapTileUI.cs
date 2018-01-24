using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HomebrewCombat.Models;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace HomebrewCombat
{
    public partial class MapTileUI : Form
    {
        List<ImageSource> imageList;




        public MapTileUI()
        {
            
            InitializeComponent();
            imageList = FileHandler.GetImageLayoutFromFile();
            




        }

        public bool IsEmpty(Bitmap imageCheck)
        {
            var data = imageCheck.LockBits(new Rectangle(0, 0, imageCheck.Width, imageCheck.Height),
                ImageLockMode.ReadOnly, imageCheck.PixelFormat);
            var bytes = new byte[data.Height * data.Stride];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
            imageCheck.UnlockBits(data);
            return bytes.All(x => x == 0);
        }



        public void TileUserInput(PictureBox pictureBox, ImageSource image)
        {


            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";


                DialogResult result = dlg.ShowDialog();

                if (result == DialogResult.OK)
                {

                    if (File.Exists(Path.Combine("dungeonlayout", Path.GetFileName(dlg.FileName))))
                    {

                        image.name = pictureBox.Name;
                        image.path = Path.Combine("dungeonlayout", Path.GetFileName(dlg.FileName));

                    }
                    else
                    {
                        FileHandler.SaveDungeonLayoutToFile(imageList);

                        File.Copy(dlg.FileName, Path.Combine("dungeonlayout", Path.GetFileName(dlg.FileName)), false);

                        image.name = pictureBox.Name;
                        image.path = Path.Combine("dungeonlayout", Path.GetFileName(dlg.FileName));


                    }




                }











            }





            RefreshTile(pictureBox, image);



        }

        public void RefreshTile(PictureBox pictureBox, ImageSource image)
        {


            if (!(String.IsNullOrEmpty(image.path)))
            {
                if (image.visible)
                {
                    pictureBox.Image = new Bitmap(image.path);
                }
                else
                {


                    string path = @"dungeonlayout\wallpaper\" + image.name + ".jpeg";
                    pictureBox.Image = Image.FromFile(path);
                }

            }
            else
            {
                string path = @"dungeonlayout\wallpaper\" + image.name + ".jpeg";
                pictureBox.Image = Image.FromFile(path);
                image.path = path;
            }
        }

        public void EnableFoW(PictureBox pictureBox, ImageSource image)
        {



            image.visible = false;







            RefreshTile(pictureBox, image);

        }

        public void DisableFoW(PictureBox pictureBox, ImageSource image)
        {



            if (!(String.IsNullOrEmpty(image.path)))
            {

                image.visible = true;
            }
            else
            {
                image.visible = false;
            }





            RefreshTile(pictureBox, image);

        }

        public void Reset()
        {
            imageList.Clear();

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    ImageSource image = imageList.FirstOrDefault(z => z.name == x.Name);

                    if (image == null)
                    {
                        image = new ImageSource();
                        image.name = x.Name;
                        image.path = "";
                        image.visible = true;
                        imageList.Add(image);


                    }

                    RefreshTile((PictureBox)x, image);


                }
            }
        }

        public void LoadMap(ImageSource image)
        {



            Image map = Image.FromFile(image.path);


            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 10; j++)
                {



                    Bitmap bmp = new Bitmap(70, 70);
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(map, new Rectangle(0, 0, 70, 70), new Rectangle(i * 70, j * 70, 70, 70), GraphicsUnit.Pixel);
                    g.Dispose();





                    ImageSource imageSource = imageList.First(x => x.name == "pb" + (j + 1) + "x" + (i + 1));
                    Control[] test = Controls.Find(imageSource.name, true);
                    PictureBox pictureBox = (PictureBox)test[0];



                    if (!IsEmpty(bmp))
                    {
                        pictureBox.Image = bmp;
                        string filename = Path.GetFileNameWithoutExtension(image.path) + i + "x" + j;
                        string path = @"dungeonlayout\" + filename + ".jpeg";
                        try
                        {
                            bmp.Save(path, ImageFormat.Jpeg);
                        }
                        catch
                        {

                        }


                        imageSource.path = path;

                    }

                    
                    pictureBox.BackColor = Color.Black;

                    











                }
            }



        }

        public void LoadWallpaper()
        {

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Bitmap bmp = new Bitmap(70, 70);
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(Properties.Resources.Stradh, new Rectangle(0, 0, 70, 70), new Rectangle(i * 70, j * 70, 70, 70), GraphicsUnit.Pixel);
                    g.Dispose();

                    //ImageSource image = imageList.First(x => x.name == "pb" + (j + 1) + "x" + (i + 1));
                    //Control[] test = Controls.Find(image.name, true);
                    //PictureBox pictureBox = (PictureBox)test[0];
                    //pictureBox.Image = bmp;


                    string path = @"dungeonlayout\wallpaper\pb" + (j + 1) + "x" + (i + 1) + ".jpeg";
                    try
                    {
                        if (!Directory.Exists(@"dungeonlayout\wallpaper"))
                        {
                            Directory.CreateDirectory(@"dungeonlayout\wallpaper");
                        }

                        bmp.Save(path, ImageFormat.Jpeg);
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void pb1x1_Click(object sender, EventArgs e)
        {
            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x1.Name);

            if (ModifierKeys.HasFlag(Keys.Control))
            {
                TileUserInput(pb1x1, image);
            }
            else
            {


                if (image.visible == false)
                {
                    DisableFoW(pb1x1, image);
                }
                else
                {
                    EnableFoW(pb1x1, image);
                }
            }



        }
        private void pb1x2_Click(object sender, EventArgs e)
        {
            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x2.Name);
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                TileUserInput(pb1x2, image);
            }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x2, image);
                }
                else
                {
                    EnableFoW(pb1x2, image);
                }
            }
        }
        private void pb1x3_Click(object sender, EventArgs e)
        {
            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x3.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb1x3, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x3, image);
                }
                else
                {
                    EnableFoW(pb1x3, image);
                }
            }
        }
        private void pb1x4_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x4.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb1x4, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x4, image);
                }
                else
                {
                    EnableFoW(pb1x4, image);
                }
            }

        }
        private void pb1x5_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x5.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb1x5, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x5, image);
                }
                else
                {
                    EnableFoW(pb1x5, image);
                }
            }

        }
        private void pb1x6_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x6.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb1x6, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x6, image);
                }
                else
                {
                    EnableFoW(pb1x6, image);
                }
            }

        }
        private void pb1x7_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x7.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb1x7, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x7, image);
                }
                else
                {
                    EnableFoW(pb1x7, image);
                }
            }

        }
        private void pb1x8_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x8.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb1x8, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x8, image);
                }
                else
                {
                    EnableFoW(pb1x8, image);
                }
            }

        }
        private void pb1x9_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x9.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb1x9, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x9, image);
                }
                else
                {
                    EnableFoW(pb1x9, image);
                }
            }

        }
        private void pn1x10_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x10.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb1x10, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x10, image);
                }
                else
                {
                    EnableFoW(pb1x10, image);
                }
            }

        }
        private void pb1x11_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x11.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb1x11, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x11, image);
                }
                else
                {
                    EnableFoW(pb1x11, image);
                }
            }

        }
        private void pb1x12_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x12.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb1x12, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x12, image);
                }
                else
                {
                    EnableFoW(pb1x12, image);
                }
            }

        }
        private void pb1x13_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x13.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb1x13, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x13, image);
                }
                else
                {
                    EnableFoW(pb1x13, image);
                }
            }

        }
        private void pb1x14_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x14.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb1x14, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x14, image);
                }
                else
                {
                    EnableFoW(pb1x14, image);
                }
            }

        }
        private void pb1x15_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x15.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb1x15, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x15, image);
                }
                else
                {
                    EnableFoW(pb1x15, image);
                }
            }

        }
        private void pb1x16_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb1x16.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb1x16, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb1x16, image);
                }
                else
                {
                    EnableFoW(pb1x16, image);
                }
            }

        }
        private void pb2x1_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x1.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x1, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x1, image);
                }
                else
                {
                    EnableFoW(pb2x1, image);
                }
            }

        }
        private void pb2x2_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x2.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x2, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x2, image);
                }
                else
                {
                    EnableFoW(pb2x2, image);
                }
            }

        }
        private void pb2x3_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x3.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x3, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x3, image);
                }
                else
                {
                    EnableFoW(pb2x3, image);
                }
            }

        }
        private void pb2x4_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x4.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x4, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x4, image);
                }
                else
                {
                    EnableFoW(pb2x4, image);
                }
            }

        }
        private void pb2x5_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x5.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x5, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x5, image);
                }
                else
                {
                    EnableFoW(pb2x5, image);
                }
            }

        }
        private void pb2x6_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x6.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x6, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x6, image);
                }
                else
                {
                    EnableFoW(pb2x6, image);
                }
            }

        }
        private void pb2x7_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x7.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x7, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x7, image);
                }
                else
                {
                    EnableFoW(pb2x7, image);
                }
            }

        }
        private void pb2x8_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x8.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x8, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x8, image);
                }
                else
                {
                    EnableFoW(pb2x8, image);
                }
            }

        }
        private void pb2x9_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x9.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x9, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x9, image);
                }
                else
                {
                    EnableFoW(pb2x9, image);
                }
            }

        }
        private void pb2x10_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x10.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x10, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x10, image);
                }
                else
                {
                    EnableFoW(pb2x10, image);
                }
            }

        }
        private void pb2x11_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x11.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x11, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x11, image);
                }
                else
                {
                    EnableFoW(pb2x11, image);
                }
            }

        }
        private void pb2x12_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x12.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x12, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x12, image);
                }
                else
                {
                    EnableFoW(pb2x12, image);
                }
            }

        }
        private void pb2x13_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x13.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x13, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x13, image);
                }
                else
                {
                    EnableFoW(pb2x13, image);
                }
            }

        }
        private void pb2x14_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x14.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x14, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x14, image);
                }
                else
                {
                    EnableFoW(pb2x14, image);
                }
            }

        }
        private void pb2x15_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x15.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x15, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x15, image);
                }
                else
                {
                    EnableFoW(pb2x15, image);
                }
            }

        }
        private void pb2x16_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb2x16.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb2x16, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb2x16, image);
                }
                else
                {
                    EnableFoW(pb2x16, image);
                }
            }

        }
        private void pb3x1_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x1.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x1, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x1, image);
                }
                else
                {
                    EnableFoW(pb3x1, image);
                }
            }

        }
        private void pb3x2_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x2.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x2, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x2, image);
                }
                else
                {
                    EnableFoW(pb3x2, image);
                }
            }

        }
        private void pb3x3_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x3.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x3, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x3, image);
                }
                else
                {
                    EnableFoW(pb3x3, image);
                }
            }

        }
        private void pb3x4_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x4.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x4, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x4, image);
                }
                else
                {
                    EnableFoW(pb3x4, image);
                }
            }

        }
        private void pb3x5_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x5.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x5, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x5, image);
                }
                else
                {
                    EnableFoW(pb3x5, image);
                }
            }

        }
        private void pb3x6_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x6.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x6, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x6, image);
                }
                else
                {
                    EnableFoW(pb3x6, image);
                }
            }

        }
        private void pb3x7_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x7.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x7, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x7, image);
                }
                else
                {
                    EnableFoW(pb3x7, image);
                }
            }

        }
        private void pb3x8_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x8.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x8, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x8, image);
                }
                else
                {
                    EnableFoW(pb3x8, image);
                }
            }

        }
        private void pb3x9_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x9.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x9, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x9, image);
                }
                else
                {
                    EnableFoW(pb3x9, image);
                }
            }

        }
        private void pb3x10_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x10.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x10, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x10, image);
                }
                else
                {
                    EnableFoW(pb3x10, image);
                }
            }

        }
        private void pb3x11_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x11.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x11, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x11, image);
                }
                else
                {
                    EnableFoW(pb3x11, image);
                }
            }

        }
        private void pb3x12_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x12.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x12, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x12, image);
                }
                else
                {
                    EnableFoW(pb3x12, image);
                }
            }

        }
        private void pb3x13_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x13.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x13, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x13, image);
                }
                else
                {
                    EnableFoW(pb3x13, image);
                }
            }

        }
        private void pb3x14_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x14.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x14, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x14, image);
                }
                else
                {
                    EnableFoW(pb3x14, image);
                }
            }

        }
        private void pb3x15_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x15.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x15, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x15, image);
                }
                else
                {
                    EnableFoW(pb3x15, image);
                }
            }

        }
        private void pb3x16_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb3x16.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb3x16, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb3x16, image);
                }
                else
                {
                    EnableFoW(pb3x16, image);
                }
            }

        }
        private void pb4x1_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x1.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x1, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x1, image);
                }
                else
                {
                    EnableFoW(pb4x1, image);
                }
            }

        }
        private void pb4x2_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x2.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x2, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x2, image);
                }
                else
                {
                    EnableFoW(pb4x2, image);
                }
            }

        }
        private void pb4x3_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x3.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x3, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x3, image);
                }
                else
                {
                    EnableFoW(pb4x3, image);
                }
            }

        }
        private void pb4x4_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x4.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x4, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x4, image);
                }
                else
                {
                    EnableFoW(pb4x4, image);
                }
            }

        }
        private void pb4x5_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x5.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x5, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x5, image);
                }
                else
                {
                    EnableFoW(pb4x5, image);
                }
            }

        }
        private void pb4x6_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x6.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x6, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x6, image);
                }
                else
                {
                    EnableFoW(pb4x6, image);
                }
            }

        }
        private void pb4x7_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x7.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x7, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x7, image);
                }
                else
                {
                    EnableFoW(pb4x7, image);
                }
            }

        }
        private void pb4x8_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x8.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x8, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x8, image);
                }
                else
                {
                    EnableFoW(pb4x8, image);
                }
            }

        }
        private void pb4x9_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x9.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x9, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x9, image);
                }
                else
                {
                    EnableFoW(pb4x9, image);
                }
            }

        }
        private void pb4x10_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x10.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x10, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x10, image);
                }
                else
                {
                    EnableFoW(pb4x10, image);
                }
            }

        }
        private void pb4x11_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x11.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x11, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x11, image);
                }
                else
                {
                    EnableFoW(pb4x11, image);
                }
            }

        }
        private void pb4x12_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x12.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x12, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x12, image);
                }
                else
                {
                    EnableFoW(pb4x12, image);
                }
            }

        }
        private void pb4x13_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x13.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x13, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x13, image);
                }
                else
                {
                    EnableFoW(pb4x13, image);
                }
            }

        }
        private void pb4x14_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x14.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x14, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x14, image);
                }
                else
                {
                    EnableFoW(pb4x14, image);
                }
            }

        }
        private void pb4x15_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x15.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x15, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x15, image);
                }
                else
                {
                    EnableFoW(pb4x15, image);
                }
            }

        }
        private void pb4x16_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb4x16.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb4x16, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb4x16, image);
                }
                else
                {
                    EnableFoW(pb4x16, image);
                }
            }

        }
        private void pb5x1_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x1.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x1, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x1, image);
                }
                else
                {
                    EnableFoW(pb5x1, image);
                }
            }

        }
        private void pb5x2_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x2.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x2, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x2, image);
                }
                else
                {
                    EnableFoW(pb5x2, image);
                }
            }

        }
        private void pb5x3_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x3.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x3, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x3, image);
                }
                else
                {
                    EnableFoW(pb5x3, image);
                }
            }

        }
        private void pb5x4_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x4.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x4, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x4, image);
                }
                else
                {
                    EnableFoW(pb5x4, image);
                }
            }

        }
        private void pb5x5_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x5.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x5, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x5, image);
                }
                else
                {
                    EnableFoW(pb5x5, image);
                }
            }

        }
        private void pb5x6_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x6.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x6, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x6, image);
                }
                else
                {
                    EnableFoW(pb5x6, image);
                }
            }

        }
        private void pb5x7_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x7.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x7, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x7, image);
                }
                else
                {
                    EnableFoW(pb5x7, image);
                }
            }

        }
        private void pb5x8_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x8.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x8, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x8, image);
                }
                else
                {
                    EnableFoW(pb5x8, image);
                }
            }

        }
        private void pb5x9_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x9.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x9, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x9, image);
                }
                else
                {
                    EnableFoW(pb5x9, image);
                }
            }

        }
        private void pb5x10_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x10.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x10, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x10, image);
                }
                else
                {
                    EnableFoW(pb5x10, image);
                }
            }

        }
        private void pb5x11_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x11.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x11, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x11, image);
                }
                else
                {
                    EnableFoW(pb5x11, image);
                }
            }

        }
        private void pb5x12_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x12.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x12, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x12, image);
                }
                else
                {
                    EnableFoW(pb5x12, image);
                }
            }

        }
        private void pb5x13_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x13.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x13, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x13, image);
                }
                else
                {
                    EnableFoW(pb5x13, image);
                }
            }

        }
        private void pb5x14_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x14.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x14, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x14, image);
                }
                else
                {
                    EnableFoW(pb5x14, image);
                }
            }

        }
        private void pb5x15_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x15.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x15, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x15, image);
                }
                else
                {
                    EnableFoW(pb5x15, image);
                }
            }

        }
        private void pb5x16_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb5x16.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb5x16, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb5x16, image);
                }
                else
                {
                    EnableFoW(pb5x16, image);
                }
            }

        }
        private void pb6x1_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x1.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x1, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x1, image);
                }
                else
                {
                    EnableFoW(pb6x1, image);
                }
            }

        }
        private void pb6x2_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x2.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x2, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x2, image);
                }
                else
                {
                    EnableFoW(pb6x2, image);
                }
            }

        }
        private void pb6x3_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x3.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x3, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x3, image);
                }
                else
                {
                    EnableFoW(pb6x3, image);
                }
            }

        }
        private void pb6x4_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x4.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x4, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x4, image);
                }
                else
                {
                    EnableFoW(pb6x4, image);
                }
            }

        }
        private void pb6x5_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x5.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x5, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x5, image);
                }
                else
                {
                    EnableFoW(pb6x5, image);
                }
            }

        }
        private void pb6x6_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x6.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x6, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x6, image);
                }
                else
                {
                    EnableFoW(pb6x6, image);
                }
            }

        }
        private void pb6x7_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x7.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x7, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x7, image);
                }
                else
                {
                    EnableFoW(pb6x7, image);
                }
            }

        }
        private void pb6x8_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x8.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x8, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x8, image);
                }
                else
                {
                    EnableFoW(pb6x8, image);
                }
            }

        }
        private void pb6x9_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x9.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x9, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x9, image);
                }
                else
                {
                    EnableFoW(pb6x9, image);
                }
            }

        }
        private void pb6x10_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x10.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x10, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x10, image);
                }
                else
                {
                    EnableFoW(pb6x10, image);
                }
            }

        }
        private void pb6x11_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x11.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x11, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x11, image);
                }
                else
                {
                    EnableFoW(pb6x11, image);
                }
            }

        }
        private void pb6x12_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x12.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x12, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x12, image);
                }
                else
                {
                    EnableFoW(pb6x12, image);
                }
            }

        }
        private void pb6x13_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x13.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x13, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x13, image);
                }
                else
                {
                    EnableFoW(pb6x13, image);
                }
            }

        }
        private void pb6x14_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x14.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x14, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x14, image);
                }
                else
                {
                    EnableFoW(pb6x14, image);
                }
            }

        }
        private void pb6x15_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x15.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x15, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x15, image);
                }
                else
                {
                    EnableFoW(pb6x15, image);
                }
            }

        }
        private void pb6x16_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb6x16.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb6x16, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb6x16, image);
                }
                else
                {
                    EnableFoW(pb6x16, image);
                }
            }

        }
        private void pb7x1_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x1.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x1, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x1, image);
                }
                else
                {
                    EnableFoW(pb7x1, image);
                }
            }

        }
        private void pb7x2_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x2.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x2, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x2, image);
                }
                else
                {
                    EnableFoW(pb7x2, image);
                }
            }

        }
        private void pb7x3_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x3.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x3, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x3, image);
                }
                else
                {
                    EnableFoW(pb7x3, image);
                }
            }

        }
        private void pb7x4_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x4.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x4, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x4, image);
                }
                else
                {
                    EnableFoW(pb7x4, image);
                }
            }

        }
        private void pb7x5_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x5.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x5, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x5, image);
                }
                else
                {
                    EnableFoW(pb7x5, image);
                }
            }

        }
        private void pb7x6_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x6.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x6, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x6, image);
                }
                else
                {
                    EnableFoW(pb7x6, image);
                }
            }

        }
        private void pb7x7_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x7.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x7, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x7, image);
                }
                else
                {
                    EnableFoW(pb7x7, image);
                }
            }

        }
        private void pb7x8_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x8.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x8, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x8, image);
                }
                else
                {
                    EnableFoW(pb7x8, image);
                }
            }

        }
        private void pb7x9_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x9.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x9, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x9, image);
                }
                else
                {
                    EnableFoW(pb7x9, image);
                }
            }

        }
        private void pb7x10_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x10.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x10, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x10, image);
                }
                else
                {
                    EnableFoW(pb7x10, image);
                }
            }

        }
        private void pb7x11_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x11.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x11, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x11, image);
                }
                else
                {
                    EnableFoW(pb7x11, image);
                }
            }

        }
        private void pb7x12_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x12.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x12, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x12, image);
                }
                else
                {
                    EnableFoW(pb7x12, image);
                }
            }

        }
        private void pb7x13_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x13.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x13, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x13, image);
                }
                else
                {
                    EnableFoW(pb7x13, image);
                }
            }

        }
        private void pb7x14_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x14.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x14, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x14, image);
                }
                else
                {
                    EnableFoW(pb7x14, image);
                }
            }

        }
        private void pb7x15_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x15.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x15, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x15, image);
                }
                else
                {
                    EnableFoW(pb7x15, image);
                }
            }

        }
        private void pb7x16_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb7x16.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb7x16, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb7x16, image);
                }
                else
                {
                    EnableFoW(pb7x16, image);
                }
            }

        }
        private void pb8x1_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x1.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x1, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x1, image);
                }
                else
                {
                    EnableFoW(pb8x1, image);
                }
            }

        }
        private void pb8x2_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x2.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x2, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x2, image);
                }
                else
                {
                    EnableFoW(pb8x2, image);
                }
            }

        }
        private void pb8x3_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x3.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x3, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x3, image);
                }
                else
                {
                    EnableFoW(pb8x3, image);
                }
            }

        }
        private void pb8x4_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x4.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x4, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x4, image);
                }
                else
                {
                    EnableFoW(pb8x4, image);
                }
            }

        }
        private void pb8x5_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x5.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x5, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x5, image);
                }
                else
                {
                    EnableFoW(pb8x5, image);
                }
            }

        }
        private void pb8x6_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x6.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x6, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x6, image);
                }
                else
                {
                    EnableFoW(pb8x6, image);
                }
            }

        }
        private void pb8x7_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x7.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x7, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x7, image);
                }
                else
                {
                    EnableFoW(pb8x7, image);
                }
            }

        }
        private void pb8x8_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x8.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x8, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x8, image);
                }
                else
                {
                    EnableFoW(pb8x8, image);
                }
            }

        }
        private void pb8x9_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x9.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x9, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x9, image);
                }
                else
                {
                    EnableFoW(pb8x9, image);
                }
            }

        }
        private void pb8x10_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x10.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x10, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x10, image);
                }
                else
                {
                    EnableFoW(pb8x10, image);
                }
            }

        }
        private void pb8x11_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x11.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x11, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x11, image);
                }
                else
                {
                    EnableFoW(pb8x11, image);
                }
            }

        }
        private void pb8x12_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x12.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x12, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x12, image);
                }
                else
                {
                    EnableFoW(pb8x12, image);
                }
            }

        }
        private void pb8x13_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x13.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x13, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x13, image);
                }
                else
                {
                    EnableFoW(pb8x13, image);
                }
            }

        }
        private void pb8x14_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x14.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x14, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x14, image);
                }
                else
                {
                    EnableFoW(pb8x14, image);
                }
            }

        }
        private void pb8x15_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x15.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x15, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x15, image);
                }
                else
                {
                    EnableFoW(pb8x15, image);
                }
            }

        }
        private void pb8x16_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb8x16.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb8x16, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb8x16, image);
                }
                else
                {
                    EnableFoW(pb8x16, image);
                }
            }

        }
        private void pb9x1_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x1.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x1, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x1, image);
                }
                else
                {
                    EnableFoW(pb9x1, image);
                }
            }

        }
        private void pb9x2_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x2.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x2, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x2, image);
                }
                else
                {
                    EnableFoW(pb9x2, image);
                }
            }

        }
        private void pb9x3_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x3.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x3, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x3, image);
                }
                else
                {
                    EnableFoW(pb9x3, image);
                }
            }

        }
        private void pb9x4_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x4.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x4, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x4, image);
                }
                else
                {
                    EnableFoW(pb9x4, image);
                }
            }

        }
        private void pb9x5_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x5.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x5, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x5, image);
                }
                else
                {
                    EnableFoW(pb9x5, image);
                }
            }

        }
        private void pb9x6_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x6.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x6, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x6, image);
                }
                else
                {
                    EnableFoW(pb9x6, image);
                }
            }

        }
        private void pb9x7_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x7.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x7, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x7, image);
                }
                else
                {
                    EnableFoW(pb9x7, image);
                }
            }

        }
        private void pb9x8_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x8.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x8, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x8, image);
                }
                else
                {
                    EnableFoW(pb9x8, image);
                }
            }

        }
        private void pb9x9_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x9.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x9, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x9, image);
                }
                else
                {
                    EnableFoW(pb9x9, image);
                }
            }

        }
        private void pb9x10_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x10.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x10, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x10, image);
                }
                else
                {
                    EnableFoW(pb9x10, image);
                }
            }

        }
        private void pb9x11_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x11.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x11, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x11, image);
                }
                else
                {
                    EnableFoW(pb9x11, image);
                }
            }

        }
        private void pb9x12_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x12.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x12, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x12, image);
                }
                else
                {
                    EnableFoW(pb9x12, image);
                }
            }

        }
        private void pb9x13_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x13.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x13, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x13, image);
                }
                else
                {
                    EnableFoW(pb9x13, image);
                }
            }

        }
        private void pb9x14_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x14.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x14, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x14, image);
                }
                else
                {
                    EnableFoW(pb9x14, image);
                }
            }

        }
        private void pb9x15_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x15.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x15, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x15, image);
                }
                else
                {
                    EnableFoW(pb9x15, image);
                }
            }

        }
        private void pb9x16_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb9x16.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb9x16, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb9x16, image);
                }
                else
                {
                    EnableFoW(pb9x16, image);
                }
            }

        }
        private void pb10x1_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x1.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x1, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x1, image);
                }
                else
                {
                    EnableFoW(pb10x1, image);
                }
            }

        }
        private void pb10x2_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x2.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x2, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x2, image);
                }
                else
                {
                    EnableFoW(pb10x2, image);
                }
            }

        }
        private void pb10x3_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x3.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x3, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x3, image);
                }
                else
                {
                    EnableFoW(pb10x3, image);
                }
            }

        }
        private void pb10x4_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x4.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x4, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x4, image);
                }
                else
                {
                    EnableFoW(pb10x4, image);
                }
            }

        }
        private void pb10x5_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x5.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x5, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x5, image);
                }
                else
                {
                    EnableFoW(pb10x5, image);
                }
            }

        }
        private void pb10x6_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x6.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x6, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x6, image);
                }
                else
                {
                    EnableFoW(pb10x6, image);
                }
            }

        }
        private void pb10x7_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x7.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x7, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x7, image);
                }
                else
                {
                    EnableFoW(pb10x7, image);
                }
            }

        }
        private void pb10x8_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x8.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x8, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x8, image);
                }
                else
                {
                    EnableFoW(pb10x8, image);
                }
            }

        }
        private void pb10x9_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x9.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x9, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x9, image);
                }
                else
                {
                    EnableFoW(pb10x9, image);
                }
            }

        }
        private void pb10x10_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x10.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x10, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x10, image);
                }
                else
                {
                    EnableFoW(pb10x10, image);
                }
            }

        }
        private void pb10x11_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x11.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x11, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x11, image);
                }
                else
                {
                    EnableFoW(pb10x11, image);
                }
            }

        }
        private void pb10x12_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x12.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x12, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x12, image);
                }
                else
                {
                    EnableFoW(pb10x12, image);
                }
            }

        }
        private void pb10x13_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x13.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x13, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x13, image);
                }
                else
                {
                    EnableFoW(pb10x13, image);
                }
            }

        }
        private void pb10x14_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x14.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x14, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x14, image);
                }
                else
                {
                    EnableFoW(pb10x14, image);
                }
            }

        }
        private void pb10x15_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x15.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x15, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x15, image);
                }
                else
                {
                    EnableFoW(pb10x15, image);
                }
            }

        }
        private void pb10x16_Click(object sender, EventArgs e)
        {

            ImageSource image = imageList.FirstOrDefault(x => x.name == pb10x16.Name);

            if (ModifierKeys.HasFlag(Keys.Control)) { TileUserInput(pb10x16, image); }
            else
            {
                if (image.visible == false)
                {
                    DisableFoW(pb10x16, image);
                }
                else
                {
                    EnableFoW(pb10x16, image);
                }
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            ShowAll();
        }

        public void ShowAll()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    ImageSource image = imageList.FirstOrDefault(z => z.name == x.Name);
                    image.visible = true;
                    RefreshTile((PictureBox)x, image);


                }
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {

            HideAll();
        }

        public void HideAll()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    ImageSource image = imageList.FirstOrDefault(z => z.name == x.Name);
                    image.visible = false;
                    RefreshTile((PictureBox)x, image);


                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            imageList = FileHandler.GetImageLayoutFromFile();

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    ImageSource image = imageList.FirstOrDefault(z => z.name == x.Name);
                    RefreshTile((PictureBox)x, image);


                }
            }



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FileHandler.SaveDungeonLayoutToFile(imageList);




        }

        private void MapTileUI_Load(object sender, EventArgs e)
        {
           
            LoadWallpaper();
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    ImageSource image = imageList.FirstOrDefault(z => z.name == x.Name);

                    if (image == null)
                    {
                        image = new ImageSource();
                        image.name = x.Name;
                        image.path = "";
                        image.visible = true;
                        imageList.Add(image);


                    }

                    RefreshTile((PictureBox)x, image);


                }
            }

            FileHandler.SaveDungeonLayoutToFile(imageList);

        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This action will take some time, and will reset and replace all currently placed tiles. Do you want to continiue?", "Are you sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Reset();
                ImageSource image = imageList.First(x => x.name == "pb1x1");

                TileUserInput(pb1x1, image);
                LoadMap(image);
            }



        }
    }
}

