namespace ddelgadoS5.Views;

public partial class vPersona : ContentPage
{
    private int? idPersonaSeleccionada = null;

    public vPersona()
	{
		InitializeComponent();
	}

	private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        // Restaurar elementos
        idPersonaSeleccionada = null;
        txtNombre.Text = "";
        btnAgregar.Text = "Agregar Persona";

        List<Models.Persona> people = App._personRepo.GetAllPerson();
        listaPersonas.ItemsSource = people;
    }   

	private void btnGuardar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";

        if (idPersonaSeleccionada == null)
        {
            // INSERTAR
            App._personRepo.AddNewPerson(txtNombre.Text);
        }
        else
        {
            // EDITAR
            App._personRepo.EditPerson(idPersonaSeleccionada.Value, txtNombre.Text);
        }

        lblStatusMessage.Text = App._personRepo.StatusMessage;

        // Restaurar elementos
        idPersonaSeleccionada = null;
        txtNombre.Text = "";
        btnAgregar.Text = "Agregar Persona";

        // Recargar lista
        List<Models.Persona> people = App._personRepo.GetAllPerson();
        listaPersonas.ItemsSource = people;
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var idPersona = (int)button.CommandParameter;

        lblStatusMessage.Text = "";
        App._personRepo.DeletePerson(idPersona);
        lblStatusMessage.Text = App._personRepo.StatusMessage;

        // Restaurar elementos
        idPersonaSeleccionada = null;
        txtNombre.Text = "";
        btnAgregar.Text = "Agregar Persona";

        // Recargar lista persona
        List<Models.Persona> people = App._personRepo.GetAllPerson();
        listaPersonas.ItemsSource = people;
    }

    private void btnEditar_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var idPersona = (int)button.CommandParameter;

        // Buscar la persona seleccionada
        var persona = App._personRepo.GetAllPerson()
            .FirstOrDefault(p => p.Id == idPersona);

        if (persona != null)
        {
            idPersonaSeleccionada = persona.Id;
            txtNombre.Text = persona.Name;

            btnAgregar.Text = "Editar Persona";
            lblStatusMessage.Text = "Editando registro...";
        }
    }
}