namespace Doctor_Model.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        /// <summary>
        /// Es un arreglo de bytes (byte[]) que almacena la versión encriptada de la contraseña del usuario.
        /// </summary>
        public byte[]? PasswordHash { get; set; }
        /// <summary>
        /// Un "salto" es una secuencia aleatoria de bytes agregada antes de hacer el hash de la contraseña.
        /// </summary>
        public byte[]? PasswordSalt { get; set; }
    }
}
