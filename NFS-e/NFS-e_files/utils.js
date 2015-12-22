
Number.prototype.format = function(n, x, s, c) {
  var re = '\\d(?=(\\d{' + (x || 3) + '})+' + (n > 0 ? '\\D' : '$') + ')',
    num = this.toFixed(Math.max(0, ~~n));
  return (c ? num.replace('.', c) : num).replace(new RegExp(re, 'g'), '$&amp;' + (s || ','));
}

Number.prototype.formatNf = function() {
  var s = this.toString();
  return s.substring(0, 4) + '/'
    + parseInt(s.substring(5));
}

Number.prototype.formatCnpj = function() {
  var s = this.toString();
  var pad = 14 - s.length;
  for (var i = 0; i < pad; i++)
    s = '0' + s;
  return s.substring(0, 2) + '.'
    + s.substring(2, 5) + '.'
    + s.substring(5, 8) + '/'
    + s.substring(8, 12) + '-'
    + s.substring(12, 14);
}

Number.prototype.formatCpf = function() {
  var s = this.toString();
  var pad = 11 - s.length;
  for (var i = 0; i < pad; i++)
    s = '0' + s;
  return s.substring(0, 3) + '.'
    + s.substring(3, 6) + '.'
    + s.substring(6, 9) + '-'
    + s.substring(9, 11);
}

Date.prototype.formatCompetencia = function() {
  return this.getMonth() + 1 + '/' + this.getFullYear();
}

function displayText(id, text) {
  var span = document.getElementById(id);
  span.innerText = span.textContent = text;
}

function displayValue(id, value) {
  var text = value.format(2, 3, '.', ',');
  displayText(id, text);
}

function displayAddress(id, address) {
  var cep = address.cep.toString();
  var text = address.endereco + ', ' + address.numero + ', '
    + address.bairro + ' - Cep: ' + cep.substring(0, 5) + '-' + cep.substring(5, 8);
  displayText(id, text);
}