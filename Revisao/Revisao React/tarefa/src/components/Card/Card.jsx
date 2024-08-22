import { useState } from 'react'
import './Card.css'
import iconDelete from '../../assets/icons/icon-delete.png'
import iconCheck from '../../assets/icons/icon-check.png'
import iconEdit from '../../assets/icons/icon-edit.png'



function Card({text, complete = false, onDelete, onEdit}) {
    const [check, setCheck] = useState(false)

    return (
        <>
            {check !== true ?
                (<>
                    <div className='card'>
                        <div className='part-left'>
                            <button className='check' onClick={() => setCheck(true)}>

                            </button>
                            <p className='text-card'>{text}</p>
                        </div>


                        <div className='part-left'>
                            <button className='buttons' onClick={onDelete}>
                                <img className='icon-false' src={iconDelete} alt='' />
                            </button>
                            <button className='buttons' onClick={onEdit}>
                                <img className='icon-false' src={iconEdit} alt='' />
                            </button>
                        </div>
                    </div>
                </>)

                :

                (<>
                    <div className='card card-true'>
                        <div className='part-left'>
                            <button className='check check-true' onClick={() => setCheck(false)}>
                                <img src={iconCheck} alt='' />
                            </button>
                            <p className='text-card text-card-true'>{text}</p>
                        </div>


                        <div className='part-left'>
                            <button className='buttons buttons-true' onClick={onDelete}>
                                <img src={iconDelete} alt='' />
                            </button>
                            <button className='buttons buttons-true' onClick={onEdit}>
                                <img src={iconEdit} alt='' />
                            </button>
                        </div>
                    </div>
                </>)}


        </>
    )
}

export default Card





// import React, { useState } from 'react';
// // Importe suas imagens aqui
// import iconDelete from './path/to/iconDelete.svg'; // Atualize o caminho conforme necessário
// import iconEdit from './path/to/iconEdit.svg'; // Atualize o caminho conforme necessário
// import iconCheck from './path/to/iconCheck.svg'; // Atualize o caminho conforme necessário

// function Card({ text, complete = false, onDelete, onEdit }) {
//     const [check, setCheck] = useState(complete); // Inicializa check com base na prop complete

//     return (
//         <>
//             {check !== true ?
//                 (<div className='card'>
//                     <div className='part-left'>
//                         <button className='check' onClick={() => setCheck(true)}>
//                             {/* Se complete for verdadeiro, mostre o ícone de check */}
//                             {complete && <img src={iconCheck} alt='' />}
//                         </button>
//                         <p className='text-card'>{text}</p>
//                     </div>

//                     <div className='part-right'>
//                         <button className='buttons' onClick={onDelete}>
//                             <img src={iconDelete} alt='' />
//                         </button>
//                         <button className='buttons' onClick={onEdit}>
//                             <img src={iconEdit} alt='' />
//                         </button>
//                     </div>
//                 </div>)
//                 :
//                 (<div className='card card-true'>
//                     <div className='part-left'>
//                         <button className='check check-true' onClick={() => setCheck(false)}>
//                             <img src={iconCheck} alt='' />
//                         </button>
//                         <p className='text-card text-card-true'>{text}</p>
//                     </div>

//                     <div className='part-right'>
//                         <button className='buttons buttons-true' onClick={onDelete}>
//                             <img src={iconDelete} alt='' />
//                         </button>
//                         <button className='buttons buttons-true' onClick={onEdit}>
//                             <img src={iconEdit} alt='' />
//                         </button>
//                     </div>
//                 </div>)
//             }
//         </>
//     );
// }

// export default Card;