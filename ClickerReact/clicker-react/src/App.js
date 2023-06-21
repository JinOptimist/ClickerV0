import './App.css';
import SeniorityLevel from './components/SeniorityLevel';

function App() {
  const userName = 'Smile';
  const currentLevelName = 'Junior'
  const exp = 10
  const coins = 50

  return (
    <div className="dev-clicker">
      <div>
        Привет <span className='doc'>1.a</span> {userName}.
        Твой уровень: <span className='doc'>1.b</span> {currentLevelName}.
        Твой опыт: <span className='doc'>1.c</span> {exp}.
        Твои сбережения: <span className='doc'>1.d</span> {coins}
      </div>
      <div style={{ display: 'flex' }}>
        <SeniorityLevel seniority='1'></SeniorityLevel>
        <SeniorityLevel seniority='2'></SeniorityLevel>
        <SeniorityLevel seniority='3'></SeniorityLevel>
      </div>
      <div>
        footer
      </div>
    </div>
  );
}

export default App;
