import Button from '@mui/material/Button';
import dataProvider from '../services/dataProvider';
import { useEffect, useState } from 'react';
import './SeniorityLevel.css';

function SeniorityLevel({ seniority }) {
  // base on seniorityLevel we will get
  const { getLevelDetails } = dataProvider();

  const [data, setData] = useState({})

  useEffect(() => {
    getLevelDetails(seniority)
      .then((data) => {
        setData(data)
      })
  })

  // Example of level icons
  // https://cdn.w600.comps.canstockphoto.com/software-developer-levels-from-junior-drawing_csp89007397.jpg
  return (
    <div className='level'>
      <div>
        <span className='doc'>2.a</span> {data.name}[{seniority}]
      </div>
      <div>
        <span className='doc'>2.b</span> <img src='https://cdn-icons-png.flaticon.com/512/566/566985.png' />
      </div>
      <div>
        <Button variant="contained">Учиться</Button>
        [Exp: +{data.learningStepSize}]
      </div>
      <div>
        <Button variant="contained">Работать</Button>
        [Coins: +Exp*{data.expSalaryRate}]
      </div>
    </div>
  );
}

export default SeniorityLevel;
