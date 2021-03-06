﻿using System;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Text.RegularExpressions;

namespace banka_Vzhled
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DesignStart();
        }

        void DesignStart()
        {
            //StartStopDays.Visibility = Visibility.Visible;
            panelSideMenu.Height = Height;
            panelLogo.Width = panelSideMenu.Width;
            BTNmainOperator.Width = panelSideMenu.Width;
            BTNvytvorit.Width = panelSideMenu.Width;
            BTNbankomat.Width = panelSideMenu.Width;
            BTNvkladomat.Width = panelSideMenu.Width;
            panelPenize.Width = panelSideMenu.Width;
            panelPenize.Background = new SolidColorBrush(Color.FromRgb(27, 67, 90));
            ohraniceniNahore.Width = Width - 250;
            ohraniceniNahore.Background = new SolidColorBrush(Color.FromRgb(23, 21, 32));
            ohraniceniDole.Width = ohraniceniNahore.Width;
            ohraniceniDole.Background = ohraniceniNahore.Background;
            panelPenize.Visibility = Visibility.Collapsed;
            imageLogo.Height = panelLogo.Height;
            imageLogo.Width = panelLogo.Width;
            //imageLogo.Source = new BitmapImage(new Uri(@"C:\Users\Alex\Desktop\banka_Vzhled\media\logo.png"));
            BTNmainOperator.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            jmeno.Width = panelVytvorit.Width;
            pin.Width = jmeno.Width;
            zustatek.Width = jmeno.Width;
            MoznostiUctuLabel.Width = panelInfoUcty.Width;
            MoznostiUctuLabel.Height = panelInfoUcty.Height - MoznostiUctu.Height;
            panelVytvorit.Visibility = Visibility.Hidden;
            panelInfoUcty.Visibility = Visibility.Hidden;
            zadejtePIN.Width = panelDisplej.Width;
            BTNpotvrdit.Width = zadejtePIN.Width;
            panelPINuspech.Visibility = Visibility.Hidden;
            panelNumpad.Visibility = Visibility.Hidden;
            panelDisplej.Visibility = Visibility.Hidden;
            pin.MaxLength = 4;
            zadejtePIN.MaxLength = 4;
            Hodnota.Width = panelPINuspech.Width;
            PlusMesic.Visibility = Visibility.Visible;
            ZrychlenyCas();
        } //Design aplikace
        void DesignOperator()
        {
            //StartStopDays.Visibility = Visibility.Visible;
            PlusMesic.Visibility = Visibility.Visible;
            //Kalendar.Visibility = Visibility.Visible;
            VypsaneUcty.Visibility = Visibility.Visible;
            InfoUctyLabel.Visibility = Visibility.Visible;
            panelVytvorit.Visibility = Visibility.Hidden;
            panelInfoUcty.Visibility = Visibility.Hidden;
            panelPINuspech.Visibility = Visibility.Hidden;
            panelNumpad.Visibility = Visibility.Hidden;
            panelDisplej.Visibility = Visibility.Hidden;
        }
        void DesignPenize()
        {
            if (panelPenize.Visibility == Visibility.Visible) panelPenize.Visibility = Visibility.Collapsed;
            else panelPenize.Visibility = Visibility.Visible;
        } //Design sub-panelu na bankomat a vkladomat a samotné okno
        void DesignVytvorit()
        {
            //StartStopDays.Visibility = Visibility.Hidden;
            PlusMesic.Visibility = Visibility.Hidden;
            //Kalendar.Visibility = Visibility.Hidden;
            VypsaneUcty.Visibility = Visibility.Hidden;
            InfoUctyLabel.Visibility = Visibility.Hidden;
            panelPINuspech.Visibility = Visibility.Hidden;
            panelNumpad.Visibility = Visibility.Hidden;
            panelDisplej.Visibility = Visibility.Hidden;

            jmeno.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(txt_GotKeyboardFocus);
            jmeno.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(txt_LostKeyboardFocus);
            pin.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(txt_GotKeyboardFocus);
            pin.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(txt_LostKeyboardFocus);
            zustatek.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(txt_GotKeyboardFocus);
            zustatek.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(txt_LostKeyboardFocus);
            //BTNvytvorit.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            panelVytvorit.Visibility = Visibility.Visible;
            panelInfoUcty.Visibility = Visibility.Visible;
            jmeno.Text = "";
            pin.Text = "";
            zustatek.Text = "";
            MoznostiUctu.SelectedValue = null;
            jmeno.Focus();
            pin.Focus();
            zustatek.Focus();
            MoznostiUctu.Focus();
            //MoznostiUctuLabel.Content = "Spořící účet Vám každý měsíc\npřidá určitý obnos peněz. Záleží,\njaký úrok Vám vaše banka dá.\nS naší bankou máte měsíční úrok\n2%. To znamená, že Vám každý\nměsíc přijdou 2% z Vašeho\nzůstatku na účtě.";
            //MoznostiUctuLabel.Content = "Spořící studentský účet Vám\nkaždý měsíc přidá určitý obnos\npeněz. Záleží, jaký úrok Vám vaše\nbanka dá. S naší bankou máte\nměsíční úrok 0,1%. To znamená,\nže Vám každý měsíc přijde 0,1% z\nVašeho zůstatku na účtě. Navíc\njste omezeni limitem jednorázo-\nvého výběru, který je u nás\n3000Kč.";
        }
        void DesignSplatky()
        {
            InfoUctyLabel.Visibility = Visibility.Hidden;
        }
        void DesignNapoveda()
        {
            InfoUctyLabel.Visibility = Visibility.Hidden;
        }

        private void BTNpenize_Click(object sender, RoutedEventArgs e)
        {
            DesignPenize();
        }

        private void BTNmainOperator_Click(object sender, RoutedEventArgs e)
        {
            DesignOperator();
        }

        private void BTNvytvorit_Click(object sender, RoutedEventArgs e)
        {
            DesignVytvorit();
        }

        private void txt_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                if (((TextBox)sender).Foreground == Brushes.Gray)
                {
                    ((TextBox)sender).Text = "";
                    ((TextBox)sender).Foreground = Brushes.White;
                }
            }
        }
        private void txt_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                if (((TextBox)sender).Text == "")
                {
                    ((TextBox)sender).Foreground = Brushes.Gray;
                    if (((TextBox)sender).Name == "jmeno") ((TextBox)sender).Text = "Název účtu";
                    else if (((TextBox)sender).Name == "pin") ((TextBox)sender).Text = "PIN";
                    else ((TextBox)sender).Text = "Počáteční vklad";
                }
            }
        }

        private void BTNbankvklad_Click(object sender, RoutedEventArgs e)
        {
            zadejtePIN.Text = "";
            PlusMesic.Visibility = Visibility.Hidden;
            //StartStopDays.Visibility = Visibility.Hidden;
            VypsaneUcty.Visibility = Visibility.Visible;
            InfoUctyLabel.Visibility = Visibility.Hidden;
            panelNumpad.Visibility = Visibility.Visible;
            panelDisplej.Visibility = Visibility.Visible;
            panelVytvorit.Visibility = Visibility.Hidden;
            panelInfoUcty.Visibility = Visibility.Hidden;
            //Kalendar.Visibility = Visibility.Hidden;
            if (((Button)sender).Name == "BTNbankomat") labelPINuspech.Content = "Zadejte hodnotu, kterou chcete vybrat";
            else if (((Button)sender).Name == "BTNvkladomat") labelPINuspech.Content = "Zadejte hodnotu, kterou chcete vložit";
        }
        public DateTime CasProgramu = DateTime.Now;
        public bool placeno;
        List<Ucet> Ucty = new List<Ucet>();
        public bool BeziDny = false;

        private void VytvorUcet_Click(object sender, RoutedEventArgs e)
        {
            bool Existuje = false;
            foreach (Ucet Item in Ucty)
            {
                if (jmeno.Text == Item.Nazev)
                {
                    Existuje = true;
                    break;
                }
                else Existuje = false;
            }

            if (zustatek.Text == "") zustatek.Text = "0";
            if (MoznostiUctu.SelectedValue != null)
            {
                if (jmeno.Text != "")
                {
                    if (!Existuje)
                    {
                        switch (MoznostiUctu.SelectionBoxItem.ToString())
                        {
                            case "Spořící":
                                Ucty.Add(new Sporici(jmeno.Text, Convert.ToDouble(zustatek.Text), 2, Convert.ToInt32(pin.Text), CasProgramu));
                                break;
                            case "Studentský":
                                Ucty.Add(new Studentsky(jmeno.Text, Convert.ToDouble(zustatek.Text), 0.1, Convert.ToInt32(pin.Text), 3000, CasProgramu));
                                break;
                            case "Kreditní":
                                Ucty.Add(new Kreditni(jmeno.Text, -Convert.ToDouble(zustatek.Text), 20, Convert.ToInt32(pin.Text), CasProgramu));
                                break;
                        }
                        foreach (Ucet Item in Ucty)
                        {
                            if (Item.Nazev == jmeno.Text) VypsaneUcty.Items.Add(Item.Nazev.ToString()); //Zabránění vytváření účtů navíc
                        }
                        DesignOperator();
                    }
                    else MessageBox.Show("Zadejte jiný název účtu", "Účet již existuje!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else MessageBox.Show("Zadejte název účtu", "CHYBA", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show("Vyberte typ účtu, který si chcete založit", "CHYBA", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        object vybrane;
        private void VypsaneUcty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (panelPINuspech.Visibility == Visibility.Visible) VypsaneUcty.SelectedItem = vybrane; //Zabránění vybrat si jiný účet při výběru peněz
            foreach (Ucet Item in Ucty)
            {
                if (Item.Nazev == VypsaneUcty.SelectedItem.ToString())
                {
                    InfoUctyLabel.Content = Item.ToString();
                }
            }
            vybrane = VypsaneUcty.SelectedItem;
        }
        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void number_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "b1":
                    zadejtePIN.Text += "1";
                    break;
                case "b2":
                    zadejtePIN.Text += "2";
                    break;
                case "b3":
                    zadejtePIN.Text += "3";
                    break;
                case "b4":
                    zadejtePIN.Text += "4";
                    break;
                case "b5":
                    zadejtePIN.Text += "5";
                    break;
                case "b6":
                    zadejtePIN.Text += "6";
                    break;
                case "b7":
                    zadejtePIN.Text += "7";
                    break;
                case "b8":
                    zadejtePIN.Text += "8";
                    break;
                case "b9":
                    zadejtePIN.Text += "9";
                    break;
                case "b0":
                    zadejtePIN.Text += "0";
                    break;
            }
        }

        private void ZadejtePIN_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (VypsaneUcty.SelectedItem != null)
            {
                foreach (Ucet Item in Ucty)
                {
                    if (Item.Nazev == VypsaneUcty.SelectedItem.ToString())
                    {
                        if (Item.PIN.ToString() == zadejtePIN.Text)
                        {
                            panelDisplej.Visibility = Visibility.Hidden;
                            panelPINuspech.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
            else
            {
                if (zadejtePIN.Text != "")
                {
                    MessageBox.Show("Musíte si vybrat účet, abyste mohli zadávat PIN kód", "Nevybraný účet");
                    zadejtePIN.Text = "";
                }
            }
        }

        private void BTNpotvrdit_Click(object sender, RoutedEventArgs e)
        {
            if (labelPINuspech.Content.ToString() == "Zadejte hodnotu, kterou chcete vložit")
            {
                foreach (Ucet Item in Ucty)
                {
                    if (Item.Nazev == VypsaneUcty.SelectedItem.ToString())
                    {
                        if (Item is Kreditni)
                        {
                            if (((Kreditni)Item).Zustatek + Convert.ToDouble(Hodnota.Text) > 0)
                            { 
                                MessageBox.Show($"Potřeboval jste splatit pouze {-Item.Zustatek}, proto jsme potřebné peníze uhradili a vrátili Vám {Convert.ToDouble(Hodnota.Text) + Item.Zustatek}.");
                                Item.Zustatek = 0;
                            }
                            else Item.Zustatek += Convert.ToDouble(Hodnota.Text);
                        }
                        else Item.Zustatek += Convert.ToDouble(Hodnota.Text);
                    }
                }
            }
            else if (labelPINuspech.Content.ToString() == "Zadejte hodnotu, kterou chcete vybrat")
            {
                foreach (Ucet Item in Ucty)
                {
                    if (Item.Nazev == VypsaneUcty.SelectedItem.ToString())
                    {
                        if (Item is Studentsky && ((Studentsky)Item).MaxVyber < Convert.ToInt16(Hodnota.Text)) MessageBox.Show("Zadaná suma překračuje limit maximálního jednorázového výběru", "CHYBA", MessageBoxButton.OK, MessageBoxImage.Error);
                        if (Item.Zustatek - Convert.ToDouble(Hodnota.Text) >= 0 && !(Item is Kreditni) || Item is Kreditni) Item.Zustatek -= Convert.ToDouble(Hodnota.Text);
                        else MessageBox.Show("Zadaná suma překračuje limit Vašeho stavu na účtu", "CHYBA", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            foreach (Ucet Item in Ucty)
            {
                if (Item.Nazev == VypsaneUcty.SelectedItem.ToString())
                {
                    InfoUctyLabel.Content = Item.ToString();
                }
            }
            Hodnota.Text = "";
        }

        private void PlusMesic_Click(object sender, RoutedEventArgs e)
        {
            CasProgramu = CasProgramu.AddMonths(1);
            //Kalendar.SelectedDate = CasProgramu;
            UbehlMesic(Ucty);
            foreach (Ucet Item in Ucty)
            {
                if (Item.Nazev == VypsaneUcty.SelectedItem.ToString())
                {
                    InfoUctyLabel.Content = Item.ToString();
                }
            }
        }
        public void ZrychlenyCas()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            void dispatcherTimer_Tick(object sender, EventArgs e)
            {
                if (BeziDny)
                {
                    //casProgramu = casProgramu.AddDays(1);
                    CasProgramu = CasProgramu.AddDays(1);
                    //Kalendar.SelectedDate = CasProgramu;
                    UbehlMesic(Ucty);
                }
            }
        }
        private void UbehlMesic(List<Ucet> ucty)
        {
            try
            {
                foreach (Sporici Item in ucty)
                {
                    TimeSpan rozdil = CasProgramu - Item.DatumZalozeni;
                    if (rozdil >= TimeSpan.FromDays(31))
                    {
                        Item.Zustatek *= Item.Urok / 100 + 1;
                        Item.Zustatek = Math.Round(Item.Zustatek, 2);
                    }
                    Item.DatumZalozeni = Item.DatumZalozeni.AddMonths(1);
                }
            }
            catch (Exception)
            {
            }
            try
            {
                foreach (Studentsky Item in ucty)
                {
                    TimeSpan rozdil = CasProgramu - Item.DatumZalozeni;
                    if (rozdil >= TimeSpan.FromDays(31))
                    {
                        Item.Zustatek *= Math.Round(Item.Urok / 100 + 1, 2);
                    }
                    Item.DatumZalozeni = Item.DatumZalozeni.AddMonths(1);
                }
            }
            catch (Exception)
            {
            }
            try
            {
                foreach (Kreditni Item in ucty)
                {
                    TimeSpan rozdil = CasProgramu - Item.DatumZalozeni;
                    if (rozdil >= TimeSpan.FromDays(31))
                    {
                        Item.Zustatek *= Math.Round(Item.Urok / 100 + 1, 2);
                    }
                    Item.DatumZalozeni = Item.DatumZalozeni.AddMonths(1);
                }
            }
            catch (Exception)
            {
            }
        } //Vypočetní úroku po uplynutí jednoho měsíce
        string pomoc = "Tento program byl vytvořen v rámci maturitního předmětu. Každé tlačítko Vám ukáže jiné okno. V hlavním okně můžete sledovat informace o svých účtech a rychle se překlikávat mezi měsíci. V panelu vytvořit si vytváříte účet. Abyste si vytvořili účet, musíte zadat název účtu, PIN, počáteční vklad a typ účtu, následně stačí jen potvrdit výběr. V kolonce peníze si musíte vybrat, zda chcete do bankomatu, nebo do vkladomatu. V obou případech si musíte vybrat účet a zadat od něho PIN kód. A podle toho, v jaké jste kolonce, si buď vyberete peníze, nebo si peníze uložíte.";
        private void BTNnapoveda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(pomoc, "Nápověda na použití aplikace na simulaci bankovních účtů", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
        }
        /*private void StartStopDays_Click(object sender, RoutedEventArgs e)
{
if (BeziDny) BeziDny = false;
else BeziDny = true;
}*/
    }
}
