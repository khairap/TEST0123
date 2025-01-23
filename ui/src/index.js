import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import store from './store';
import App from './App';
import ErrorBoundary from './ErrorBoundary';

const root = ReactDOM.createRoot(document.getElementById('root'));

console.log('Store:', store.getState());

console.log('React version:', React.version);

root.render(
  <ErrorBoundary>
    <Provider store={store}>
    <React.StrictMode>     
      <App />
    </React.StrictMode> 
    </Provider>
  </ErrorBoundary>    

);
