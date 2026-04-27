
    function apiBase() {
      return document.getElementById('baseUrl').value.replace(/\/$/, '');
    }

    function setResponse(statusText, data, ok) {
      const status = document.getElementById('status');
      status.textContent = statusText;
      status.className = 'status ' + (ok ? 'ok' : 'error');
      document.getElementById('output').textContent = typeof data === 'string'
        ? data
        : JSON.stringify(data, null, 2);
    }

    async function request(method, path, body) {
      try {
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

        setResponse(`${method} ${path} -> ${response.status} ${response.statusText}`, data, response.ok);
      } catch (error) {
        setResponse(`${method} ${path} -> request failed`, String(error), false);
      }
    }

    function currentBookDto() {
      return {
        bookId: Number(document.getElementById('bookId').value),
        copyNumber: Number(document.getElementById('copyNumber').value)
      };
    }

    function currentShelfDto() {
      return {
        bookshelfId: Number(document.getElementById('shelfId').value),
        shelfs: Number(document.getElementById('shelfSize').value),
        rooms: Number(document.getElementById('shelfRow').value)
      };
    }

    function currentUserDto() {
      return {
        userId: Number(document.getElementById('userId').value),
        name: document.getElementById('userName').value,
        mail: document.getElementById('userMail').value,
        title: document.getElementById('userTitle').value
      };
    }

    function currentLoanDto() {
      return {
        userId: Number(document.getElementById('loanUserId').value),
        bookId: Number(document.getElementById('loanBookId').value),
        copyNumber: Number(document.getElementById('loanCopyNumber').value)
      };
    }

    function createBook() { request('POST', '/api/books', currentBookDto()); }
    function updateBook() { request('PUT', '/api/books', currentBookDto()); }
    function deleteBook() { request('DELETE', '/api/books', currentBookDto()); }
    function getBook() {
      const dto = currentBookDto();
      request('GET', `/api/books/${dto.bookId}/${dto.copyNumber}`);
    }

    function createShelf() { request('POST', '/api/bookshelfs', currentShelfDto()); }
    function updateShelf() { request('PUT', '/api/bookshelfs', currentShelfDto()); }
    function deleteShelf() {
      const id = Number(document.getElementById('shelfId').value);
      request('DELETE', `/api/bookshelfs/${id}`);
    }
    function addBookToShelf() {
      const shelfId = Number(document.getElementById('shelfId').value);
      const body = {
        bookId: Number(document.getElementById('placeBookId').value),
        copyNumber: Number(document.getElementById('placeCopyNumber').value)
      };
      request('POST', `/api/bookshelfs/${shelfId}/books`, body);
    }
    function removeBookFromShelf() {
      const shelfId = Number(document.getElementById('shelfId').value);
      const body = {
        bookId: Number(document.getElementById('placeBookId').value),
        copyNumber: Number(document.getElementById('placeCopyNumber').value)
      };
      request('DELETE', `/api/bookshelfs/${shelfId}/books`, body);
    }

    function createUser() { request('POST', '/api/users', currentUserDto()); }
    function updateUser() { request('PUT', '/api/users', currentUserDto()); }
    function deleteUser() {
      const id = Number(document.getElementById('userId').value);
      request('DELETE', `/api/users/${id}`);
    }
    function getUser() {
      const id = Number(document.getElementById('userId').value);
      request('GET', `/api/users/${id}`);
    }

    function loanBook() { request('POST', '/api/users/loan', currentLoanDto()); }
    function returnBook() { request('DELETE', '/api/users/loan', currentLoanDto()); }

    function sendManual() {
      const method = document.getElementById('manualMethod').value;
      const path = document.getElementById('manualPath').value;
      const raw = document.getElementById('manualBody').value.trim();
      const body = raw ? JSON.parse(raw) : undefined;
      request(method, path, body);
    }