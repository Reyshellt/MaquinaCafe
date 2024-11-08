using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaquinaCafe.Tests
{
    [TestClass]
    public class UnitTest1
    {
        // Configuración inicial de ingredientes (esto puede estar en el Program principal, pero lo agregamos aquí para referencia)
        static int vasosPequenos = 2;
        static int vasosMedianos = 5;
        static int vasosGrandes = 5;

        [TestInitialize]
        public void TestInitialize()
        {
            // Inicializa la cantidad de vasos antes de cada prueba
            vasosPequenos = 2;
            vasosMedianos = 5;
            vasosGrandes = 5;
        }

        [TestMethod]
        public void SeleccionarTamanoVaso_ReturnsCorrectSizeForSmall()
        {
            // Act: Llamar al método SeleccionarTamanoVaso para seleccionar el vaso pequeño
            int tamano = SeleccionarTamanoVaso("1");

            // Assert: Validar el tamaño de vaso y la cantidad restante de vasos pequeños
            Assert.AreEqual(3, tamano, "El tamaño del vaso debería ser 3 Oz para la opción pequeña.");
            Assert.AreEqual(1, vasosPequenos, "La cantidad de vasos pequeños debería reducirse en 1.");
        }

        // Método auxiliar que simula SeleccionarTamanoVaso para realizar pruebas sin modificar el código original
        public int SeleccionarTamanoVaso(string opcion)
        {
            int tamano = 0;

            switch (opcion)
            {
                case "1":
                    if (vasosPequenos > 0)
                    {
                        tamano = 3;
                        vasosPequenos--;
                    }
                    break;
                case "2":
                    if (vasosMedianos > 0)
                    {
                        tamano = 5;
                        vasosMedianos--;
                    }
                    break;
                case "3":
                    if (vasosGrandes > 0)
                    {
                        tamano = 7;
                        vasosGrandes--;
                    }
                    break;
                default:
                    tamano = 0;
                    break;
            }

            return tamano;
        }
    }
}
