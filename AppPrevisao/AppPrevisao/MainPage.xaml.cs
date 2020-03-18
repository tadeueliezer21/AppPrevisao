using System;
using System.ComponentModel;
using Xamarin.Forms;
using AppPrevisao.Model;

namespace AppPrevisao
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnPrevisao_Clicked(object sender, EventArgs e)
        {
            try
            {
                
                if (!String.IsNullOrEmpty(txtCidade.Text))
                {
                    Tempo temp = await TempoService.TempoService.GetPrevisaoTempo(txtCidade.Text);
                    this.BindingContext = temp;
                    btnPrevisao.Text = "Nova previsão";
                }
                else
                {
                    await DisplayAlert("Campo vazio", "Entre com o nome da cidade", "Sair");
                    txtCidade.Focus();
                }
                
            }
            catch(Exception err)
            {
                await DisplayAlert("Ocorreu um erro", err.Message, "Sair");
            }

        }
    }
}
