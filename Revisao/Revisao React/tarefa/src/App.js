import logo from './logo.svg';
import './App.css';
import Card from './components/Card/Card';
import { useState } from 'react';


function App() {
  const [lista, setLista] = useState([{ id: 1, text: 'test', complete: false },])
  const [searchTerm, setSearchTerm] = useState("");
  const [editingId, setEditingId] = useState(null); // Estado para controle de edição

  const deleteItem = (id) => {
    setLista(currentList => currentList.filter(item => item.id !== id));
  };

  const editItem = (id, newText) => {
    setLista(currentList =>
      currentList.map(item =>
        item.id === id ? { ...item, text: newText } : item
      )
    );
    setEditingId(null); // Finaliza a edição
  };

  const handleEditClick = (id) => {
    setEditingId(id);
  };

  const filtrarLista = lista.filter(lista =>
    lista.text.toLowerCase().includes(searchTerm.toLowerCase())
  );
  return (
    <body>
      <div className='blocao'>
        <h1>Terca feira, <span style={{ color: "#8758FF" }}>24</span> de julho</h1>

        <input className='input' placeholder='Procurar tarefa' />

        {filtrarLista.map((item) => (
          <Card
            key={item.id}
            text={editingId === item.id ? <input value={item.text} onChange={(e) => editItem(item.id, e.target.value)} /> : item.text}
            complete={item.complete}
            onDelete={() => deleteItem(item.id)}
            onEdit={() => handleEditClick(item.id)}
          />
        ))}


      </div>
      <button className='button-create'>Nova tarefa</button>
    </body>

  );
}
export default App;









