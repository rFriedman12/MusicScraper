import React, { useEffect, useState } from 'react';
import axios from 'axios';

function Home() {

    const [musicCds, setMusicCds] = useState([]);

    useEffect(() => {
        async function getMusicCds() {
            const { data } = await axios.get('/api/music/getall');
            setMusicCds(data);
        }

        getMusicCds();
    })

    return (
        <div className='container'>
            {musicCds.map(cd => {
                return <div className='row mt-5'>
                    <a href={`${cd.productLink}`}>
                        <img className='img-thumbnail w-75' src={`${cd.imageLink}`}></img>
                        <br />
                        <h6>{cd.title}</h6>
                        {cd.isNew && <span>New!</span>}
                    </a>
                </div>
            })}
        </div>)
}

export default Home;