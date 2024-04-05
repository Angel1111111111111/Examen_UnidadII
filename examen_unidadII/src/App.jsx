import React, { useState } from 'react';

const App = () => {
  const [nombre, setNombre] = useState('');
  const [genero, setGenero] = useState('masculino');
  const [peso, setPeso] = useState('');
  const [altura, setAltura] = useState('');
  const [resultado, setResultado] = useState('');

  const calcularIMC = () => {
    const alturaMetros = altura / 100;
    const imc = peso / (alturaMetros * alturaMetros);
    return imc.toFixed(1);
  };


  const determinarCategoriaIMC = (imc) => {
    if (imc < 18.5) {
      return 'Bajo peso';
    } else if (imc >= 18.5 && imc <= 24.9) {
      return 'Peso normal';
    } else if (imc >= 25.0 && imc <= 29.9) {
      return 'Sobrepeso';
    } else if (imc >= 30.0 && imc <= 34.9) {
      return 'Obesidad grado I';
    } else if (imc >= 35.0 && imc <= 39.9) {
      return 'Obesidad grado II';
    } else {
      return 'Obesidad grado III';
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const imc = calcularIMC();
    const categoriaIMC = determinarCategoriaIMC(imc);
    setResultado(`Tu masa corporal es ${imc}, Tu peso es ${categoriaIMC}`);
  };

  return (
    <div className='bg-gray-500'>
      <div className="container mx-auto flex justify-center items-center min-h-screen">
        <div className="bg-gray-100 px-10 py-8 rounded-lg shadow-md">
          <h2 className="text-2xl font-bold mb-4">Calculadora de IMC</h2>
          <form onSubmit={handleSubmit} id="imcForm" className="mb-4">
            <div className="mb-4">
              <label htmlFor="nombre" className="mr-2">Nombre:</label>
              <input type="text" id="nombre" name="nombre" value={nombre} onChange={(e) => setNombre(e.target.value)} required className="border border-gray-300 rounded px-2 py-1" />
            </div>
            <div className="mb-4">
              <label htmlFor="genero" className="mr-2">Género:</label>
              <select id="genero" name="genero" value={genero} onChange={(e) => setGenero(e.target.value)} required className="border border-gray-300 rounded px-2 py-1">
                <option value="masculino">Masculino</option>
                <option value="femenino">Femenino</option>
              </select>
            </div>
            <div className="mb-4">
              <label htmlFor="peso" className="mr-2">Peso (kg):</label>
              <input type="number" id="peso" name="peso" value={peso} onChange={(e) => setPeso(e.target.value)} required className="border border-gray-300 rounded px-2 py-1" />
            </div>
            <div className="mb-4">
              <label htmlFor="altura" className="mr-2">Altura (cm):</label>
              <input type="number" id="altura" name="altura" value={altura} onChange={(e) => setAltura(e.target.value)} required className="border border-gray-300 rounded px-2 py-1" />
            </div>
            <button type="submit" className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-700">Calcular IMC</button>
          </form>
          <div id="resultado" className={`text-xl ${resultado === 'Bajo peso' ? 'text-blue-500' : resultado === 'Peso normal' ? 'text-green-500' : resultado === 'Sobrepeso' ? 'text-yellow-500' : 'text-red-500'}`}>{resultado}</div>
        </div>
      </div>
    </div>
  );

}

export default App;
