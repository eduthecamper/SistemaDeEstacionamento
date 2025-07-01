import React, {useEffect, useState} from 'react';
import api from '../services/api';

export default function Dashboard({refresh}) {
    const [vagas, setVagas] = useState({Maximo: 0, Ocupadas: 0, Disponiveis: 0});

    useEffect(() => {
        api.get('/vagas').then(res => setVagas(res.data));
    }, [refresh]);

    return(
        <div className='card mb-3'>
            <div className='card-body'>
                <h5 className='card-title'>Resumo do Estacionamento</h5>
                <p>Vagas Totais: {vagas.maximo}</p>
                <p>Ocupadas: {vagas.ocupadas}</p>
                <p>Disponíveis: {vagas.disponiveis}</p>
            </div>
        </div>
    );
}