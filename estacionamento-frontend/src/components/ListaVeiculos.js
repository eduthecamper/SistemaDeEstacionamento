import React, {useEffect, useState} from 'react';
import api from '../services/api';

export default function ListaVeiculos({refresh}) {
    const [veiculos, setVeiculos] = useState([]);

    useEffect(() => {
        api.get('/veiculos').then(res => setVeiculos(res.data));
    }, [refresh]);

    return (
        <div className='card mb-3'>
            <div className='card-body'>
                <h5 className='card-title'>Veículos Estacionados</h5>
                <table className='table table-striped'>
                    <thead>
                        <tr>
                            <th>Placa</th>
                            <th>Entrada</th>
                        </tr>
                    </thead>
                    <tbody>
                        {veiculos.map((v,i) => (
                            <tr key = {i}>
                                <td>{v.placa}</td>
                                <td>{new Date(v.dataHoraEntrada).toLocaleString()}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    )
}