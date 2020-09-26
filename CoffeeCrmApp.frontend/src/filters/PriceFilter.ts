function PriceFilter (number: number) {
  if (isNaN(number)) {
    return '-';
  }
  return number.toFixed(2) + ' ₽';
}

export default PriceFilter;