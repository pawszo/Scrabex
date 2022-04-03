import React from 'react';
import Tuple from 'react';

export default function useToggle(initialValue = false) : [boolean,() => void]{
  const [value, setValue] = React.useState(initialValue);
  const toggle = React.useCallback(() => {
    setValue(v => !v);
  }, []);
  return [value, toggle];
}