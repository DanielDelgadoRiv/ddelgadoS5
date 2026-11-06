namespace ddelgadoS5.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

	private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        List<Models.Persona> people = App._personRepo.GetAllPerson();
        listaPersonas.ItemsSource = people;
    }   

	private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";
        App._personRepo.AddNewPerson(txtNombre.Text);
        lblStatusMessage.Text = App._personRepo.StatusMessage;
    }
}