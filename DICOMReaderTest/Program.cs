using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitware.VTK;

namespace DICOMReaderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DICOMReaderTest1();
        }

        public static void DICOMReaderTest1()
        {
            vtkDICOMImageReader dcmReader = vtkDICOMImageReader.New();
            dcmReader.SetFileName("../../../../res/CT/CT.00002.00002.dcm");
            dcmReader.Update();


            vtkImageViewer2 imageViewer = vtkImageViewer2.New();
            imageViewer.SetInputConnection(dcmReader.GetOutputPort());

            vtkRenderWindow renderWin = vtkRenderWindow.New();
            imageViewer.SetRenderWindow(renderWin);

            renderWin.AddRenderer(imageViewer.GetRenderer());

            vtkRenderWindowInteractor interactor = vtkRenderWindowInteractor.New();
            interactor.SetRenderWindow(renderWin);

            renderWin.Render();
            interactor.Start();

        }
    }
}
