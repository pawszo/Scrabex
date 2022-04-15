import React from 'react';
import { StateProvider } from './components/StateProvider';
import { Filter } from './functions/Filter';

function App() {
  return (
    <StateProvider>
      <Filter />
    </StateProvider>
  );
}

export default App;
