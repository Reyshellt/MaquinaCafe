using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaquinaCafe.Tests
{
    [TestClass]
    public class UnitTest1
    {
        // Configuraci�n inicial de ingredientes (esto puede estar en el Program principal, pero lo agregamos aqu� para referencia)
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
            // Act: Llamar al m�todo SeleccionarTamanoVaso para seleccionar el vaso peque�o
            int tamano = SeleccionarTamanoVaso("1");

            // Assert: Validar el tama�o de vaso y la cantidad restante de vasos peque�os
            Assert.AreEqual(3, tamano, "El tama�o del vaso deber�a ser 3 Oz para la opci�n peque�a.");
            Assert.AreEqual(1, vasosPequenos, "La cantidad de vasos peque�os deber�a reducirse en 1.");
        }

        // M�todo auxiliar que simula SeleccionarTamanoVaso para realizar pruebas sin modificar el c�digo original
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
