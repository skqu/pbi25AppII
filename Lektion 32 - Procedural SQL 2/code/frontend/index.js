let loggedInUserId = null;

function apiBase() {
  return document.getElementById('baseUrl').value.replace(/\/$/, '');
}

function setStatus(message, ok = true) {
  const status = document.getElementById('status');
  status.textContent = message;
  status.className = 'status ' + (ok ? 'ok' : 'error');
}

function setOutput(data) {
  document.getElementById('output').textContent =
    typeof data === 'string'
      ? data
      : JSON.stringify(data, null, 2);
}

async function request(method, path, body) {
  const options = {
    method,
    headers: {
      'Content-Type': 'application/json'
    }
  };

  if (body !== undefined && method !== 'GET') {
    options.body = JSON.stringify(body);
  }

  const response = await fetch(apiBase() + path, options);
  const text = await response.text();

  let data;
  try {
    data = text ? JSON.parse(text) : {};
  } catch {
    data = text;
  }

  setOutput(data);

  if (!response.ok) {
    throw new Error(`${method} ${path} failed: ${response.status}`);
  }

  return data;
}

async function login() {
  const userId = Number(document.getElementById('userId').value);

  try {
    const user = await request('GET', `/api/users/${userId}`);

    loggedInUserId = userId;
    document.getElementById('loginStatus').textContent =
      `Logged in as user ${userId}`;

    setStatus('Login successful.');
    loadLoans();
  } catch (error) {
    loggedInUserId = null;
    document.getElementById('loginStatus').textContent = 'Not logged in';
    setStatus(error.message, false);
  }
}

function currentLoanDto() {
  return {
    userId: loggedInUserId,
    bookId: Number(document.getElementById('bookId').value),
    copyNumber: Number(document.getElementById('copyNumber').value)
  };
}

function requireLogin() {
  if (loggedInUserId === null) {
    setStatus('You must login first.', false);
    return false;
  }

  return true;
}

async function loanBook() {
  if (!requireLogin()) return;

  try {
    const result = await request('POST', '/api/users/loan', currentLoanDto());
    console.log(result);
    if ( result != "Book copy is already loaned")
    {
      setStatus('Book loaned.');
      loadLoans();
    }else
    {
      setStatus(result);
    }
  } catch (error) {
    setStatus(error.message, false);
  }
}

async function returnBook() {
  if (!requireLogin()) return;

  try {
    await request('DELETE', '/api/users/loan', currentLoanDto());
    setStatus('Book returned.');
    loadLoans();
  } catch (error) {
    setStatus(error.message, false);
  }
}

async function loadLoans() {
  if (!requireLogin()) return;

  const loansElement = document.getElementById('loans');
  loansElement.innerHTML = '<p class="small">Loading loans...</p>';

  try {
    // Change this path if your backend uses another route.
    const loans = await request('GET', `/api/users/${loggedInUserId}/loans`);

    if (!Array.isArray(loans) || loans.length === 0) {
      loansElement.innerHTML = '<p class="small">You have no loaned books.</p>';
      return;
    }

    loansElement.innerHTML = loans.map(loan => `
      <div class="loanItem">
        <strong>Book ID:</strong> ${loan.bookId}<br>
        <strong>Copy number:</strong> ${loan.copyNumber}
      </div>
    `).join('');

    setStatus('Loans loaded.');
  } catch (error) {
    loansElement.innerHTML = '<p class="small">Could not load loans.</p>';
    setStatus(error.message, false);
  }
}