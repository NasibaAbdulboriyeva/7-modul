class Employee {
  constructor(id, name, position, salary) {
    this.id = id;
    this.name = name;
    this.position = position;
    this.salary = salary;
  }
}

let employees = [];
let empIdCounter = 1;

const form = document.getElementById('employeeForm');
const tableBody = document.querySelector('#employeeTable tbody');

form.addEventListener('submit', function (e) {
  e.preventDefault();
  const id = document.getElementById('empId').value;
  const name = document.getElementById('name').value.trim();
  const position = document.getElementById('position').value.trim();
  const salary = parseFloat(document.getElementById('salary').value);

  if (!name || !position || isNaN(salary)) return;

  if (id) {
    updateEmployee(parseInt(id), name, position, salary);
  } else {
    addEmployee(name, position, salary);
  }

  form.reset();
  document.getElementById('empId').value = '';
  renderTable();
});

function addEmployee(name, position, salary) {
  const emp = new Employee(empIdCounter++, name, position, salary);
  employees.push(emp);
}

function updateEmployee(id, name, position, salary) {
  const emp = employees.find(e => e.id === id);
  if (emp) {
    emp.name = name;
    emp.position = position;
    emp.salary = salary;
  }
}

function deleteEmployee(id) {
  employees = employees.filter(e => e.id !== id);
  renderTable();
}

function editEmployee(id) {
  const emp = employees.find(e => e.id === id);
  if (emp) {
    document.getElementById('empId').value = emp.id;
    document.getElementById('name').value = emp.name;
    document.getElementById('position').value = emp.position;
    document.getElementById('salary').value = emp.salary;
  }
}

function renderTable() {
  tableBody.innerHTML = '';
  employees.forEach((emp, index) => {
    const row = document.createElement('tr');

    row.innerHTML = `
      <td>${index + 1}</td>
      <td>${emp.name}</td>
      <td>${emp.position}</td>
      <td>$${emp.salary.toFixed(2)}</td>
      <td class="actions">
        <button class="edit" onclick="editEmployee(${emp.id})">Edit</button>
        <button class="delete" onclick="deleteEmployee(${emp.id})">Delete</button>
      </td>
    `;

    tableBody.appendChild(row);
  });
}
