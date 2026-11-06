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

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var idPersona = (int)button.CommandParameter;

        lblStatusMessage.Text = "";

        App._personRepo.DeletePerson(idPersona);

        lblStatusMessage.Text = App._personRepo.StatusMessage;

        List<Models.Persona> people = App._personRepo.GetAllPerson();
        listaPersonas.ItemsSource = people;
    }
}